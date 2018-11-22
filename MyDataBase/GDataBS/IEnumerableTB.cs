using System.Collections;

namespace GDataBS
{
    public class IEnumerableTB
    {
    }
    public class Fruit
    {
        public string fruitName;
        public string fruitPrice;
        public Fruit(string fruitName, string fruitPrice)
        {
            this.fruitName = fruitName;
            this.fruitPrice = fruitPrice;
        }
    }
    class FruitShop : IEnumerable
    {
        Fruit[] fruits = new Fruit[10];
        int current = 0;
        public void Add(Fruit fruit)
        {
            fruits[current] = fruit;
            current++;
        }

        public IEnumerator GetEnumerator()
        {
            return new FruitEnumerator(fruits);
        }

    }
    public class FruitEnumerator : IEnumerator
    {
        Fruit[] fruits;
        int current = -1;
        public FruitEnumerator(Fruit[] fruits)
        {
            this.fruits = fruits;
        }

        //这里需要做一个判断，因为有可能此时current<0或超出数组长度
        public object Current
        {
            get { return CurrentFruit(); }
        }
        object CurrentFruit()
        {
            if (current < 0 || current > fruits.Length)
                return null;
            else
                return fruits[current];
        }

        public bool MoveNext()
        {
            current++;
            if (current < fruits.Length && fruits[current] != null)
                return true;
            return false;
        }

        public void Reset()
        {
            current = 0;
        }
    }
}