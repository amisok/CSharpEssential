using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsInStore
{
    class Article
    {
        double price;
        string name, store;

        public double Price
        {
            get { return price; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Store
        {
            get { return store; }
        }

        public Article(double price, string name, string store)
        {
            this.price = price;
            this.name = name;
            this.store = store;
        }

        public string ShowInfo()
        {
            return string.Format($"Item {name} is in {store} store and costs {price} grn");
        }
    }

    class Store
    {
        Article[] articles;

        public Store(int length)
        {
            articles = new Article[length];
        }

        public void AddItem(double price, string name, string store, int index)
        {
            if (index >= 0 && index < articles.Length)
                articles[index] = new Article(price, name, store);
        }

        public string this[int index]
        {
            get
            {
                for (int i = 0; i < articles.Length; i++)
                {
                    if (i == index)
                    {
                        return articles[index].ShowInfo();
                    }
                }
                return string.Format($"The index {index} isn't found ");
            }
        }

        public string this[string item]
        {
            get
            {
                for (int i = 0; i < articles.Length; i++)
                {
                    if (articles[i].Name == item)
                    {
                        return articles[i].ShowInfo();
                    }
                }
                return string.Format($"The {item} item isn't here ");
            }
        }

        public void ShowStore()
        {
            for (int i = 0; i < articles.Length; i++)
            {
                Console.WriteLine($"Item {articles[i].Name} is in {articles[i].Store} store and costs {articles[i].Price} grn");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Store shop = new Store(3);

            shop.AddItem(12, "table", "METRO", 0);
            shop.AddItem(10.5, "lamp", "DOORS", 1);
            shop.AddItem(25, "sofa", "EPICENTR", 2);

            shop.ShowStore();

            Console.WriteLine(shop[1]);
            Console.WriteLine(shop["apple"]);
            Console.ReadKey();
        }
    }
}
