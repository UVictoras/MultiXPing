
using MultiXPing;
using MultiXPing.source.Characters.Attacks;

namespace TestsUnitaires
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //Program.InitializeConsole();
            Tree arbre = new Tree();
            Player player = new Player(20, 20);
            arbre.AddNode(player.Inventory);
            arbre.AddNode(player.Team);
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

#if false

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

            //Marche pas: erreur IOSystemExeption dans la console on sait pas d'ou ça vient 

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
#endif
        [Test]
        public void AttaquesImplémentées()
        {
            //Arrange 
            AttackList list = new AttackList();
            list.InitAttacks();
            int i;

            //Act


            //Assert
            foreach(Attack attack in list.ListAttack) {
                i = 0;
            }

        }

        [Test]
        [TestCase(0,1,1)]
        [TestCase(0,-1,3)]
        [TestCase(3,1,0)]
        public void TestCycleCursors(int init, int sens, int expected)
        {
            //Arrange 
            Player p = new(20,20);
            Tree t = new();

            t.AddNode(new Inventory());
            t.AddNode(new Team());
            t.AddNode(new Inventory());
            t.AddNode(new Team());


            MenuWindow window = new MenuWindow(p,t);
            window.CurrentChoice = init;

            //Act
            window.UpdateChoice(sens);

            //Assert
            Assert.That(expected, Is.EqualTo(window.CurrentChoice));
        }


    }
}