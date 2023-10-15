namespace Lesson;



// коли http запрос виконується у всіх обєктів визивається Disponse
// IDisposable коли ми знищуємо клас він зразу відпрацьовує
public class BaseRepository : IDisposable
{
    private readonly IDBConnection _dbConnection;
    public BaseRepository(IDBConnection dbConnection)
    {
        _dbConnection = dbConnection;
        _dbConnection.InitConnection();
    }
    private bool disposed;

    public void Dispose()
    {
        //вивільняємо неуправляємі ресурси
        Dispose(true);
        //подавлення фіналізації
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        // якшо по деяких причинах disponse не відпрацює то відпрацює деструктор
        if (!disposed)
        {
            return;
        }
        _dbConnection.RevokeConnection();
        disposed = true;
    }
    // деструктор - обгортка над фіналайз
    ~BaseRepository() {
        // нам потрібно звільнення зєднання зразу як орпацювався http запит і ми не маємо часу поки зборщик мусору буде шукати наш обєкт на який нема силок і видалить його  тому ми реалізуємо інтерфейс IDisponsable
        //_dbConnection.RevokeConnection();
        Dispose(false); 
    }

}
public interface IDBConnection
{
    bool InitConnection();
    bool RevokeConnection();
}


