using System.ComponentModel.DataAnnotations;

namespace WpfEfCoreSample
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; } // 年齢フィールドを追加
    }
}