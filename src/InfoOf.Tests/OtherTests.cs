using NUnit.Framework;
using System;
using System.Reflection;

namespace Tests {
    public class OtherTests {
        
        [Test]
        public void Test1() {

            var MI1 = InfoOf.Type<Foo>().Method(x => x.DoWork<string>(string.Empty)).Method.GetGenericMethodDefinition();
            var MI2 = InfoOf.Type<Foo>().Method(x => Foo.DoWork()).Method;

            var MI3 = InfoOf.Type<Foo>().Method(x => x.DoWork2<string>(1, 2, x)).Method;
            var MI4 = InfoOf.Type(typeof(Foo<>));
            


            Assert.Pass();
        }

        public class Foo<T> : Foo {

        }

        public class Foo {
            public int DoWork2<T>(int A, int B, object C) {
                return 0;
            }

            public int ReturnValue { get; }
            public int DoWork<T>(T Input) {
                
                return ReturnValue;
            }

            public static void DoWork() {

            }

            public static void DoWork1() {

            }

            public static int DoWork2(string x) {
                return 0;
            }

        }


    }

}