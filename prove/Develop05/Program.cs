class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        UIManager uiManager = new UIManager(gameManager);
        uiManager.Run();
    }
}
