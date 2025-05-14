// 导入System命名空间，这样我们可以使用DateTime等类型
using System;

// 定义命名空间，确保与您现有的项目命名空间一致
namespace lizi
{
    // 定义一个公共结构体，用于存储角色的属性
    // 结构体是一种轻量级的类，适合存储简单的数据组
    public struct CharacterAttributes
    {
        // 定义属性字段，每个字段代表角色的一个属性
        public int Strength;           // 力量属性，影响物理攻击力和负重能力,使用int类型存储整数值
        public int Intelligence;       // 智力属性, 影响魔法/科技能力和学习能力
        public int Agility;            // 敏捷属性, 影响移动速度和闪避能力
        public int Constitution;       // 体质属性, 影响生命值和恢复能力
        public int Spirit;             // 灵性属性, 影响灵气吸收和修真能力
    }

    // 定义一个公共类，用于存储角色的所有信息
    // 类是C#的基本类型，可以包含数据和方法
    public class CharacterData 
    {
        // 角色基本信息，使用属性(Properties)定义
        // { get; set; }表示这是自动属性，编译器会自动为它们创建背后的字段
        public string GameID { get; set; }            // 游戏ID，使用string类型存储文本
        public string Gender { get; set; }            //性别
        public string Continent { get; set; }         // 大陆
        public string Faction { get; set; }           // 体系、阵营


        // 角色属性，使用我们上面定义的结构体类型
        public CharacterAttributes Attributes { get; set; }


        // 时间相关信息
        public DateTime SaveTime { get; set; }  // 保存时间，使用DateTime类型存储日期和时间

    }



}
