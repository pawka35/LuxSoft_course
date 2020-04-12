/* В исходном примере представлен паттерн Composite, где нарушается принцип ISP
* Следуя инструкциям ниже по тексту - получим соблюдение принципа ISP, но убедимся, что это вносит 
* излишние сущности и дубллирование кода в наш пример.
*/ 
using System;
using System.Collections.Generic;


namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //закоментируйте строку ниже
             Component root = new Composite("Root");
      
            /* Расскоментируйте строку ниже, т.к убрав абстрактые методы  add и remove из класса component - нам придется
             добавлять новый класс для коневого меню, с данными методами*/
           // RootClass root = new RootClass("Root");
            Component leaf = new Leaf("Leaf");
            Composite subtree = new Composite("Subtree");

            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Display();
        //закоментировать ниже 2 абстрактных метода
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
    }

    //раскоментируйте новый класс, объекты которого будут представлять собой корневое меню
    //class RootClass : Component
    //{
    //    List<Component> rootChildren = new List<Component>();
    //    public RootClass(string name)
    //    : base(name)
    //    { }

    //    public void Add(Component component)
    //    {
    //        rootChildren.Add(component);
    //    }

    //    public void Remove(Component component)
    //    {
    //        rootChildren.Remove(component);
    //    }

    //    public override void Display()
    //    {
    //        Console.WriteLine(name);

    //        foreach (Component component in rootChildren)
    //        {
    //            component.Display();
    //        }
    //    }
    //}

    class Composite : Component
    {
        List<Component> children = new List<Component>();

        public Composite(string name)
            : base(name)
        { }

     
        //закоментировать имплементация методов Add и Remove (т.к. они убраны из класса Component)
        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        //раскоментировать 2 метода - теперь они будут методами только для данного класса (а не отнаследованы от предка)
        //public void Add(Component component)
        //{
        //    children.Add(component);
        //}

        //public void Remove(Component component)
        //{
        //    children.Remove(component);
        //}

        public override void Display()
        {
            Console.WriteLine(name);

            foreach (Component component in children)
            {
                component.Display();
            }
        }
    }

    class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        { }

        public override void Display()
        {
            Console.WriteLine(name);
        }

        //закоментировать имплементация методов Add и Remove (т.к. они убраны из класса Component)

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
