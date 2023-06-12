using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowingHidingPrac
{
    class Program
    {
        class Animal
        {
            public virtual void Eat() //virtual 키워드는 무조건 오버라이딩에서 사용하는 것은 아니다. 하이딩에서도 사용 가능
            {
                Console.WriteLine("냠냠 먹습니다.");
            }
        }
        class Dog : Animal
        {
            public void Eat() //하이딩
            {
                Console.WriteLine("촵촵 먹습니다.");
            }
        }
        class Cat : Animal
        {
            public override void Eat() //오버라이딩
            {
                Console.WriteLine("뇸뇸 먹습니다.");
            }
        }

        class Parent
        {
            public int variable = 273;
            public void Method()
            {
                Console.WriteLine("부모의 메서드");
            }
            public virtual void Method2()
            {
                Console.WriteLine("부모의 메서드");
            }
        }
        class Child : Parent
        {
            public new string variable = "shadowing"; // (hiding) new 키워드를 안써도 돌아가지만 써주는게 좋음
            public new void Method()
            {
                Console.WriteLine("자식의 메서드");
            }
            public override void Method2() //override 할때 부모클래스의 메서드에는 virtual 키워드가 들어가야 한다.
            {
                Console.WriteLine("자식의 메서드");
            }
        }
        public static int number = 10;
        static void Main(string[] args)
        {
            int number = 20;
            Console.WriteLine(number);
            Child child = new Child();
            Console.WriteLine(child.variable); // shadowing 출력
            Parent p = child;
            Console.WriteLine(p.variable); // 273 출력

            child.Method();
            p.Method();

            child.Method2();
            p.Method2();


            List<Animal> Animals = new List<Animal>()
            {
                new Dog(), new Cat(), new Cat(), new Dog(),
                new Dog(), new Cat(), new Dog(), new Dog(),
            };
            foreach(var item in Animals)
            {
                item.Eat();
                // 하이딩한 Dog는 Animal의 Eat()이 출력되고, 오버라이딩한 Cat은 Cat의 Eat()이 출력됨
            }
        }
    }
}
