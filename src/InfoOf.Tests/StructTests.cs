using NUnit.Framework;
using System;
using System.Reflection;

namespace Tests {
    public class StructTests {

        [Test]
        public void Test1() {
            var Instance1 = new Struct_Basic() {
                Source_Name = "Source_Name",
                Dest_Name = "Dest_Name",
            };

            var Instance2 = (object)Instance1;


            var P1 = InfoOf.Type<Struct_Basic>().Field(x => x.Source_Name);
            var P2 = InfoOf.Type<Struct_Basic>().Field(x => x.Dest_Name);



            //var P2 = InfoOf.Type(typeof(Bar)).Property(nameof(Bar.Dest_Name));

            var Getter1 = P1.ValueGetter();
            var Getter2 = P1.EntityGetter();
            var Getter3 = P1.ObjectGetter();

            var Setter1 = P2.ValueSetter();
            var Setter2 = P2.EntitySetter();
            var Setter3 = P2.ObjectSetter();

            {
                var V1 = Getter1(Instance1);
                var V2 = Getter2(Instance1);
                var V3 = Getter3(Instance1);

                Setter1(Instance1, V1);

                Setter2(Instance1, V1);
                Setter2(Instance1, V2);
                Setter2(Instance1, V3);

                Setter3(Instance1, V1);
                Setter3(Instance1, V2);
                Setter3(Instance1, V3);
            }
            {
                var V1 = Getter1(Instance1);
                var V2 = Getter2(Instance1);
                var V3 = Getter3(Instance2);

                Setter3(Instance2, V1);
                Setter3(Instance2, V2);
                Setter3(Instance2, V3);
            }

            Assert.Pass();
        }

        [Test]
        public void Test2() {
            var Instance1 = new Struct_Basic() {
                Source_Name = "Tony",
                Dest_Name = "Valenti",
            };

            var Instance2 = (object)Instance1;


            var P1 = InfoOf.Type(typeof(Struct_Basic)).Field(nameof(Class_Basic.Source_Name));
            var P2 = InfoOf.Type(typeof(Struct_Basic)).Field(nameof(Class_Basic.Dest_Name));



            //var P2 = InfoOf.Type(typeof(Bar)).Property(nameof(Bar.Dest_Name));

            var Getter3 = P1.ObjectGetter();

            var Setter3 = P2.ObjectSetter();

            {
                var V3 = Getter3(Instance1);


                Setter3(Instance1, V3);
            }
            {
                var V3 = Getter3(Instance2);

                Setter3(Instance2, V3);
            }

            Assert.Pass();
        }

        [Test]
        public void Test3() {
            var Instance1 = new Struct_Basic() {
                Source_Date = DateTimeOffset.UtcNow,
            };

            var Instance2 = (object)Instance1;


            var P1 = InfoOf.Type<Struct_Basic>().Field(x => x.Source_Date);
            var P2 = InfoOf.Type<Struct_Basic>().Field(x => x.Dest_Date);



            //var P2 = InfoOf.Type(typeof(Bar)).Property(nameof(Bar.Dest_Name));

            var Getter1 = P1.ValueGetter();
            var Getter2 = P1.EntityGetter();
            var Getter3 = P1.ObjectGetter();

            var Setter1 = P2.ValueSetter();
            var Setter2 = P2.EntitySetter();
            var Setter3 = P2.ObjectSetter();

            {
                var V1 = Getter1(Instance1);
                var V2 = Getter2(Instance1);
                var V3 = Getter3(Instance1);

                Setter1(Instance1, V1);

                Setter2(Instance1, V1);
                Setter2(Instance1, V2);
                Setter2(Instance1, V3);

                Setter3(Instance1, V1);
                Setter3(Instance1, V2);
                Setter3(Instance1, V3);
            }
            {
                var V1 = Getter1(Instance1);
                var V2 = Getter2(Instance1);
                var V3 = Getter3(Instance2);

                Setter3(Instance2, V1);
                Setter3(Instance2, V2);
                Setter3(Instance2, V3);
            }

            Assert.Pass();
        }

        [Test]
        public void Test4() {
            var Instance1 = new Struct_Basic() {
                Source_Date = DateTimeOffset.UtcNow,

            };

            var Instance2 = (object)Instance1;


            var P1 = InfoOf.Type(typeof(Struct_Basic)).Field(nameof(Class_Basic.Source_Date));
            var P2 = InfoOf.Type(typeof(Struct_Basic)).Field(nameof(Class_Basic.Dest_Date));



            //var P2 = InfoOf.Type(typeof(Bar)).Property(nameof(Bar.Dest_Name));

            var Getter3 = P1.ObjectGetter();

            var Setter3 = P2.ObjectSetter();

            {
                var V3 = Getter3(Instance1);


                Setter3(Instance1, V3);
            }
            {
                var V3 = Getter3(Instance2);

                Setter3(Instance2, V3);
            }

            Assert.Pass();
        }

    }

}