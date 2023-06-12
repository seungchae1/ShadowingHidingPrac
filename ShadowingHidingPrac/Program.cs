using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowingHidingPrac
{
    class Program
    {
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
        }
    }
}
