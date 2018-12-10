using System;

namespace Algorithms
{
    public class GameAnimals
    {
        AnimalNode _root;
        public GameAnimals()
        {
            _root = new AnimalNode{Question="Это млекопитающее?"};
            var bark = new AnimalNode{Question="Оно лает?"};
            bark.YesChild=new AnimalNode{Question="Это собака"};
            bark.NoChild=new AnimalNode{Question="Это кошка"};

            var squama = new AnimalNode{Question="Оно покрыто чешуёй?"};
            squama.YesChild = new AnimalNode{Question="Это рыба"};
            squama.NoChild = new AnimalNode{Question="Это птица"};
            _root.YesChild = bark;
            _root.NoChild = squama;

        }
        public void GameStart()
        {
            while (true)
            {
                var question = _root;
                var previous = _root;
                while (!IfAnimalFound(question))
                {
                    Console.Write(question.Question);
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            previous = question;
                            question = question.YesChild;
                            break;
                        case "N":
                            previous = question;
                            question = question.NoChild;
                            break;
                        default:
                            System.Console.WriteLine("Не понял.");
                            break;
                    }
                }

                System.Console.WriteLine($"Это - {question.Question}?");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        System.Console.WriteLine("Угадал!");
                        break;
                    case "N":
                        AddAnimal(previous, question);
                        break;
                    default:
                        System.Console.WriteLine("Не понял.");
                        break;
                }

                System.Console.Write("Ещё?(Y/N)");
                var answer = Console.ReadLine().ToUpper();

                if (answer.Trim() != "Y")
                {
                    System.Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

        public void AddAnimal(AnimalNode previous, AnimalNode node)
        {
            System.Console.Write("Какое животние загадано?");
            var animalName = Console.ReadLine();
            System.Console.Write("Характеристика животного: ");
            var feature = Console.ReadLine();

            AnimalNode yesNoNode = new AnimalNode { Question = feature };
            yesNoNode.NoChild = node;
            yesNoNode.YesChild = new AnimalNode { Question = animalName };

            if (previous.YesChild == node)
                previous.YesChild = yesNoNode;
            else
                previous.NoChild = yesNoNode;

        }

        bool IfAnimalFound(AnimalNode node)
        {
            if (node.NoChild == null && node.YesChild == null)
            {
                return true;
            }

            return false;
        }
    }

    public class AnimalNode
    {
        public string Question { get; set; }
        public AnimalNode YesChild { get; set; }
        public AnimalNode NoChild { get; set; }
    }
}