using System;
using System.IO;

namespace lizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====角色创建系统=====");
            //测试1
            string gameID = GetGameID();
            string gender = GetGender();
            string continent = GetContinent();
            string faction = GetFaction();

            DisplayCharacterInfo(gameID, gender, continent,faction);

            //询问是否保存角色信息
            Console.WriteLine("\n是否要保存角色信息？（Y/N");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y"||answer == "YES") 
            {
                SaveCharacter(gameID,gender,continent,faction);
            }

            //防止程序立即关闭
            Console.WriteLine("\n按任意键退出。。。");
            Console.ReadKey();
        }

        //设置游戏ID，方法
        static string GetGameID() 
        {
            //设置游戏ID
            Console.WriteLine("请设置您的游戏ID");
            string id = Console.ReadLine();

            //添加验证
            while (string.IsNullOrWhiteSpace(id)) 
            {
                Console.WriteLine("ID不能为空，请重新输入。");
                id = Console.ReadLine();
            }
            return id;
        }
        
        //选择性别，方法
        static string GetGender()
        {
            Console.WriteLine("\n请选择性别：");
            Console.WriteLine("1.男");
            Console.WriteLine("2.女");
            string Choice = Console.ReadLine();

            if (Choice == "1")
                return"男";
            
            else if (Choice == "2")
                return"女";
            else
            {
                Console.WriteLine("未做选择，将随机分配性别");
                //实际随机选择性别
                return new Random().Next(2) == 0 ? "男" : "女";
            }

        }

        //选择出生大陆，方法
        static string GetContinent()
        {
            
            Console.WriteLine("\n请选择出生大陆");
            Console.WriteLine("1.东域仙乡");
            Console.WriteLine("2.西荒漠海");
            Console.WriteLine("3.南陨神山");
            Console.WriteLine("4.北境冰原");
            Console.WriteLine("5.中圣皇州");
            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1": return "东域仙乡";
                case "2": return "西荒漠海";
                case "3": return "南陨神山";
                case "4": return "北境冰原";
                case "5": return "中圣皇州";
                default:
                    Console.WriteLine("未做选择，默认设置为'中圣皇州'");
                    return "中圣皇州";
            }

        }
        //获取阵营/体系，方法
        static string GetFaction()
        { 
            Console.WriteLine("\n请选择阵营;");
            Console.WriteLine("1.灵气—修真体系。逆天问道，九霄伐仙。");
            Console.WriteLine("2.魔法—奥义体系。元素即规则。");
            Console.WriteLine("3.科技—机械体系。科学使人明智，科技让人闭嘴。");
            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case "1":
                    Console.WriteLine("你选择了灵气体系，将踏上修真之路。");
                    return "灵气";
                case "2":
                    Console.WriteLine("你选择了魔法体系，将掌握元素的力量。");
                    return "魔法";
                case "3":
                    Console.WriteLine("你选择了科技体系，去体悟机械的力量吧。");
                    return "科技";
                default:
                    Console.WriteLine("未做选择，将默认加入灵气体系");
                    return "灵气";
     
            }

        
        }

        //存档方法
        static void SaveCharacter(string id,string gender,string continent,string faction)
        {
            try 
            {
                //创建文档，如果不存在
                string saveFolder = "Character";
                if (!Directory.Exists(saveFolder)) 
                {
                    Directory.CreateDirectory(saveFolder);
                }

                //创建文件名
                string fileName = Path.Combine(saveFolder, id + ".txt");

                //准备存档内容
                string content =
                    $"游戏ID：{id}\r\n" +
                    $"角色性别：{gender}\r\n" +
                    $"出生地域：{continent}\r\n" +
                    $"体系：{faction}\r\n" +
                    $"保存时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";

                //写入文件
                File.WriteAllText(fileName, content);
                Console.WriteLine($"\n角色信息已成功保存到{fileName}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"\n保存角色时出错：{ex.Message}");
            }
        }



        static void DisplayCharacterInfo(string id, string gender, string continent,string faction)
        {
            Console.WriteLine("\n=====角色信息=====");
            Console.WriteLine($"游戏ID；{id}");
            Console.WriteLine($"性别：{gender}");
            Console.WriteLine($"出生大陆：{continent}");
            Console.WriteLine($"体系：{faction}");
        }
        
        
    }
}
