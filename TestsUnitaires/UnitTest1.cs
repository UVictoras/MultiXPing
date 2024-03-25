
using MultiXPing;

namespace TestsUnitaires
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //Program.InitializeConsole();
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(0, 1)]
        public void TestMarcherSurLaMap(int x, int y)
        {

            //Arrange 
            Player player = new Player(20, 20);

            //Act
            player.Move(x, y);

            //Assert
            Assert.That(player.Position.X, Is.EqualTo(20 + x));
            Assert.That(player.Position.Y, Is.EqualTo(20 + y));

        }

        [Test]
        [TestCase(1, 0, false)]
        //Sur le coffre 
        [TestCase(20, 20, false)]

        //Autour du coffre
        [TestCase(21, 20, true)]
        [TestCase(20, 21, true)]
        [TestCase(19, 20, true)]
        [TestCase(20, 19, true)]

        //En diagonal
        [TestCase(15, 15, false)]
        [TestCase(16, 15, false)]
        public void TestOuvrirCoffre(int x, int y, bool result)
        {

            //Arrange 
            Player player = new Player(x, y);
            Chest chest = new Chest(20, 20);
            chest.AddItem(new Coffee());

            Window window = new Window();
            player.onUse += chest.Interact;
            chest.PrintText += window.DrawWindowInteractive;

            //Act
            player.OnUseWindow();

            //Assert
            Assert.That(result, Is.EqualTo(window.Content == chest.Text));
        }
    }
}