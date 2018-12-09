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

            c.fireAway();

            Console.ReadKey();
        }


        private void Fired(Object sender, MyArgs args)
        {
            Console.WriteLine("Fired: " + args.MyProperty);
        }
    }


    class Counter
    {
        public EventHandler<MyArgs> eventHandler;

        public void fireAway()
        {

            var myargs = new MyArgs();
            myargs.MyProperty = 10;
            eventHandler?.Invoke(this, myargs);
        }
    }

    public class MyArgs
    {

        public int MyProperty { get; set; }

    }
}
