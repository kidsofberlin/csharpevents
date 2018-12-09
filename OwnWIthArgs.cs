using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OwnWIthArgs
    {

        public void RunIt()
        {

            var c = new Counter();
            c.eventHandler += (o,i) => Console.WriteLine("lambda");
            c.eventHandler += Fired;

            c.FireAway();

            Console.ReadKey();
        }


        private void Fired(Object sender, MyArgs args)
        {
            Console.WriteLine("Fired: " + args.SomeProperty);
        }
    }


    class Counter
    {
        public EventHandler<MyArgs> eventHandler;

        public void FireAway()
        {

            var myargs = new MyArgs();
            myargs.SomeProperty = 10;
            eventHandler?.Invoke(this, myargs);
        }
    }

    public class MyArgs
    {

        public int SomeProperty { get; set; }

    }
}
