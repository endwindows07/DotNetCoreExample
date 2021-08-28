using DotNetCoreExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExample.Services
{
    public class DbMockUpService
    {
        public List<TodoModel> Todos { get; set; }
        public List<BookModel> Books { get; set; }

        public List<(string, string, string)> MockBook { get; set; }

        public DbMockUpService()
        {

            MockBook = new List<(string, string, string)>() {
                new ("Angular for Enterprise-Ready Web Applications", "https://www.tektutorialshub.com/wp-content/uploads/2018/11/Angular-5-From-Theory-To-Practice.jpg", "This is the great book by very experienced authors. The book contains a lot of example codes that are well explained with good illustrations. This book teaches you everything you need to build an Angular application. The books start from basic and covers the advanced techniques like testing, dependency injection, and performance tuning. "),
                new ("Ng-Book: The Complete Guide to Angular", "https://www.tektutorialshub.com/wp-content/uploads/2018/11/Share-Facebook-Twitter-Pinterest.jpg", "This book very comprehensive and reader-friendly. The book is well organized and covers all the important topics in the Angular. The chapters on Data Architecture in Angular, Redux & Nativescipt is a bonus here. Also, it covers how to migrate from AngularJs to Angular. A Book worth reading"),
                new ("ASP.NET & .NET Core MVC", "https://th-live-05.slatic.net/p/7f492a91ea9d16cd4e3fab009d771051.jpg_2200x2200q80.jpg_.webp", "หนังสือ คู่มือสร้างเว็บไซต์แบบ Responsive ด้วย ASP.NET & .NET Core MVC ฉบับโปรแกรมเมอร์ โดย ศุภชัย สมพานิช"),
                new ("Google Analytics", "https://th-live-05.slatic.net/p/a13e9e08d57b09c6910beeb54722ad33.jpg_720x720q80.jpg_.webp", "หนังสือ รู้ข้อมูลเชิงลึกลูกค้าบนเว็บไซต์ด้วย Google Analytics ศุภณัฐ สุขโข"),
                new ("ASP.NET Core MVC", "https://th-live-05.slatic.net/p/9cf86052a8c6f09714625d8a81f00569.jpg_720x720q80.jpg_.webp", "คู่มือพัฒนาเว็บแอพพลิเคชั่นด้วย ASP.NET Core MVC"),
                new ("Flutter & Dart", "https://th-live-05.slatic.net/p/99293d9e7a5aa8f392961191aad99038.jpg_720x720q80.jpg_.webp", "พัฒนา Mobile App ด้วย Flutter & Dart"),
                new ("Bootstrap", "https://th-live-05.slatic.net/p/b564f963f7f7818fbc9fa08ce0989ad4.jpg_720x720q80.jpg_.webp", "สร้างเว็บไซต์แบบ Responsive ด้วย Bootstrap ร่วมกับ CSS และ JavaScript"),
                new ("Vue.js", "https://th-live-05.slatic.net/p/539e5ea55ac07cf4f4ab81eb7cecb20f.jpg_720x720q80.jpg_.webp", "พัฒนาเว็บแอพพลิเคชันด้วย Vue.js"),
                new ("React", "https://th-test-11.slatic.net/p/e10f58decbe173e41c70b8a4d184b45e.jpg", "พัฒนาเว็บแอพพลิเคชันด้วย React"),
                new ("Node.js", "https://th-test-11.slatic.net/p/5a8ae433bb92e142e442f0bdc08917b8.jpg", "พัฒนาเว็บแอพพลิเคชันด้วย Node.js"),
                new ("เขียนโปรแกรมด้วยภาษา C ", "https://th-test-11.slatic.net/p/0ed8f8c8a76c77db47e115fa320ae869.jpg", "6449 การเขียนโปรแกรมด้วยภาษา C ฉบับ 2021 อัพเดตใหม่"),
                new ("คู่มือการเขียนโปรแกรมภาษา C#", "https://th-test-11.slatic.net/p/f84bd0c541e585db33509c05fdb53d66.jpg", "เขียนโปรแกรมภาษา C#"),
                new ("SQL Server 2019", "https://th-test-11.slatic.net/p/17b6b9031782b9758b024d89f1fbe466.jpg", "บริหารและจัดการฐานข้อมูลด้วย SQL Server 2019"),
                new ("JavaScript", "https://th-test-11.slatic.net/p/2cd49669d15422cf2143f7ddc7fdd127.jpg", "คู่มือ พัฒนาเว็บและเพิ่มลูกเล่นด้วย JavaScript"),
                new ("หนังสือ Python อัพเดทล่าสุด", "https://th-test-11.slatic.net/p/a3e161e2c932d7e78813462fa4eeec43.jpg", "หนังสือ Python อัพเดทล่าสุด"),
                new ("Python", "https://th-test-11.slatic.net/p/88ce91ffa6f5f28be26ecd9b3be17565.jpg", "เขียนโปรแกรมภาษา Python GUI+Network+Database+Web"),
                new ("C# OOP", "https://th-test-11.slatic.net/p/c93451cbd51f7d62ec32727360fddfa6.jpg", "เก่ง C# ให้ครบสูตร ฉบับ OOP"),
                };

            Random random = new Random();

            Todos = new List<TodoModel>();
            Books = new List<BookModel>();

            for (int i = 0; i < 10; i++)
            {
                TodoModel todo = new TodoModel();

                todo.Id = i + 1;
                todo.Title = "Titile " + todo.Id;
                todo.Completed =  i / 2 == 0? true : false;
                Todos.Add(todo);
            }

            int index = 1;

            foreach (var item in MockBook)
            {
                BookModel book = new BookModel();
                book.Id = index;
                book.Name = item.Item1;
                book.Description = item.Item3;
                book.ImageUrl = item.Item2;
                book.Author = "Author " + index;
                book.Price = random.Next(100, 500);
                book.Count = random.Next(10, 50);
                book.IsActive = true;
                Books.Add(book);

                index++;
            }

         
        }
    }
}
