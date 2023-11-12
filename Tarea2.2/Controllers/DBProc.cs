using Tarea2._2.Models;
using SQLite;

namespace Tarea2._2.Controllers
{
    public class DBProc : ContentPage
    {
        private readonly SQLiteAsyncConnection _connection;

        public DBProc()
        { }

        public DBProc(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            // todos objetos BD
            _connection.CreateTableAsync<Firmas>().Wait();
        }

        /*  crud DBProc*/
        // create, read, update, delete

        public Task<int> AddFirma(Firmas imagen)
        {
            if (imagen.id == 0)
            {
                return _connection.InsertAsync(imagen);
            }
            else
            {
                return _connection.UpdateAsync(imagen);
            }
        }

        public Task<List<Firmas>> ListFirmas()
        {
            return _connection.Table<Firmas>().ToListAsync();
        }

        public Task<Firmas> GetFirmaID(int id)
        {
            return _connection.Table<Firmas>()
                .Where(p => p.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeleteFirma(Firmas imagen)
        {
            return _connection.DeleteAsync(imagen);
        }
    }
}