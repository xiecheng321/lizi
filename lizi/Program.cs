using System;
using System.IO;
using System.Reflection;

namespace lizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====角色创建系统=====");

            // 创建一个新的CharacterData对象
            // 'new'关键字用于创建类的实例(对象)
            CharacterData character = new CharacterData();

            // 调用方法获取用户输入并设置到character对象的属性中
            character.GameID = GetGameID();     // 设置GameID属性
            character.Gender = GetGender();     // 设置Gender属性
            character.Continent = GetContinent(); // 设置Continent属性
            character.Faction = GetFaction();   // 设置Faction属性

            // 调用AllocateAttributes方法，传入所选体系
            // 该方法返回一个CharacterAttributes结构体
            // 将返回的结构体赋值给character对象的Attributes属性
            character.Attributes = AllocateAttributes(character.Faction);

            DisplayCharacterInfo(character);

            

            //询问是否保存角色信息
            Console.WriteLine("\n是否要保存角色信息？（Y/N");
            string answer = Console.ReadLine().ToUpper();     // 读取用户输入并转换为大写
            if (answer == "Y"||answer == "YES")               // 条件判断，检查用户是否选择保存
            {
                SaveCharacter(character);                     // 调用保存方法，传入character对象
            }

            //防止程序立即关闭
            Console.WriteLine("\n按任意键退出。。。");
            Console.ReadKey();                                // 等待用户按任意键
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

        // CharacterAttributes是返回类型，表示这个方法返回一个CharacterAttributes结构体
        // AllocateAttributes是方法名
        // string faction是参数，表示这个方法接收一个名为faction的字符串参数
        static CharacterAttributes AllocateAttributes(string faction) 
        {
            // 创建一个新的CharacterAttributes结构体实例
            // new是关键字，用于创建新的对象或结构体
            // CharacterAttributes()是结构体的构造函数
            CharacterAttributes attributes = new CharacterAttributes();

            Console.WriteLine("\n=====属性分配=====");

            // $是字符串插值符号，允许在字符串中嵌入变量或表达式
            // {faction}会被替换为faction变量的实际值
            Console.WriteLine($"根据您选择的{faction}体系，系统自动分配初始属性。");

            // switch语句用于根据expression的值执行不同的代码块
            // faction是要判断的表达式
            switch (faction)
            {
                // case "灵气":表示如果faction等于"灵气"，则执行下面的代码
                case "灵气":
                    // 为结构体的各个字段赋值
                    // attributes是我们创建的结构体实例
                    // Strength等是结构体的字段
                    // =是赋值运算符，将右边的值赋给左边的变量
                    attributes.Strength = 2;       // 赋值为2
                    attributes.Intelligence = 3;   // 赋值为3
                    attributes.Agility = 2;        // 赋值为2
                    attributes.Constitution = 3;   // 赋值为3
                    attributes.Spirit = 5;         // 赋值为5

                    // 输出体系特点描述
                    Console.WriteLine("灵气体系修真者注重修炼精神与灵性，体质较强。");

                    // break语句结束当前case，防止执行下一个case
                    break;

                // 如果faction等于"魔法"，则执行下面的代码
                case "魔法":
                    attributes.Strength = 1;
                    attributes.Intelligence = 6;
                    attributes.Agility = 3;
                    attributes.Constitution = 2;
                    attributes.Spirit = 3;
                    Console.WriteLine("魔法体系法师精通元素与规则，智力出众。");
                    break;

                // 如果faction等于"科技"，则执行下面的代码
                case "科技":
                    attributes.Strength = 3;
                    attributes.Intelligence = 5;
                    attributes.Agility = 4;
                    attributes.Constitution = 2;
                    attributes.Spirit = 1;
                    Console.WriteLine("科技体系工程师善于运用机械与能源，反应迅速。");
                    break;
            }

            /*// 显示分配的属性
            Console.WriteLine("\n您的初始属性为：");

            // 使用字符串插值显示各个属性值
            Console.WriteLine($"力量: {attributes.Strength}");
            Console.WriteLine($"智力: {attributes.Intelligence}");
            Console.WriteLine($"敏捷: {attributes.Agility}");
            Console.WriteLine($"体质: {attributes.Constitution}");
            Console.WriteLine($"灵性: {attributes.Spirit}");

            // return语句返回填充好的attributes结构体
            // 这个结构体将被传回调用此方法的地方*/
            return attributes;
        }



        // 显示角色信息方法，接收一个CharacterData类型的参数

        static void DisplayCharacterInfo(CharacterData character)
        {
            Console.WriteLine("\n=====角色信息=====");
            // 使用字符串插值($)来格式化输出，{character.属性名}会被替换为实际的属性值
            Console.WriteLine($"游戏ID；{character.GameID}");             // 显示GameID
            Console.WriteLine($"性别：{character.Gender}");                // 显示性别
            Console.WriteLine($"出生大陆：{character.Continent}");         // 显示大陆
            Console.WriteLine($"体系：{character.Faction}");               // 显示体系

            // 添加属性显示部分
            Console.WriteLine("\n=====角色属性=====");

            // character.Attributes访问角色的Attributes属性
            // character.Attributes.Strength访问Attributes结构体的Strength字段
            Console.WriteLine($"力量: {character.Attributes.Strength}");
            Console.WriteLine($"智力: {character.Attributes.Intelligence}");
            Console.WriteLine($"敏捷: {character.Attributes.Agility}");
            Console.WriteLine($"体质: {character.Attributes.Constitution}");
            Console.WriteLine($"灵性: {character.Attributes.Spirit}");
        }



        //存档方法
        static void SaveCharacter(CharacterData character)
        {
            try         // try-catch块用于错误处理
            {
                //创建保存，如果不存在
                string saveFolder = "Character";          // 定义保存文件夹名称
                if (!Directory.Exists(saveFolder))         // 检查文件夹是否存在，!表示"不"
                {
                    Directory.CreateDirectory(saveFolder);       // 创建文件夹
                }

                //创建文件名，Path.Combine用于正确连接路径和文件名
                string fileName = Path.Combine(saveFolder, character.GameID + ".txt");

                // 设置保存时间为当前时间
                character.SaveTime = DateTime.Now;


                //准备存档内容,使用字符串格式化
                string content =
                    $"游戏ID：{character.GameID}\r\n" +
                    $"角色性别：{character.Gender}\r\n" +
                    $"出生地域：{character.Continent}\r\n" +
                    $"体系：{character.Faction}\r\n" +
                    $"\r\n===属性===\r\n" +
                    $"力量: {character.Attributes.Strength}\r\n" +
                    $"智力: {character.Attributes.Intelligence}\r\n" +
                    $"敏捷: {character.Attributes.Agility}\r\n" +
                    $"体质: {character.Attributes.Constitution}\r\n" +
                    $"灵性: {character.Attributes.Spirit}\r\n" +
                    $"保存时间：{character.SaveTime.ToString("yyyy-MM-dd HH:mm:ss")}";         // 格式化日期时间

                // 写入文件，File.WriteAllText会创建文件并写入内容
                File.WriteAllText(fileName, content);
                Console.WriteLine($"\n角色信息已成功保存到{fileName}");
            }
            catch (Exception ex)          // 捕获并处理可能的异常
            {
                Console.WriteLine($"\n保存角色时出错：{ex.Message}");
            }
        }


        



    }
}
