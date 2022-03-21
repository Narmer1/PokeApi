using PokeApi.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi
{
    internal class PokApiDataBase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<PokApiDataBase> Instance = new AsyncLazy<PokApiDataBase>(async () =>
        {
            var instance = new PokApiDataBase();
            CreateTableResult result = await Database.CreateTableAsync<PokemonModel>();
            return instance;
        });

        public PokemonModel BindingContext { get; private set; }

        public PokApiDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        //Méthodes de manipulations des données

        public Task<List<PokemonModel>> GetPokemonModelsAsync()
        {
            return Database.Table<PokemonModel>().ToListAsync();
        }

        public Task<List<PokemonModel>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<PokemonModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<PokemonModel> GetItemAsync(int id)
        {
            return Database.Table<PokemonModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PokemonModel item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(PokemonModel item)
        {
            return Database.DeleteAsync(item);
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (PokemonModel)BindingContext;
            PokApiDataBase database = await PokApiDataBase.Instance;
            await database.SaveItemAsync(todoItem);
        }

        public Task<bool> isEmpty()
        {
            return Task.Run(() => 0 == Database.Table<PokemonModel>().ToListAsync().Result.Count);
        }

    }
}
