using ProyectoMetodologia.Models;
using System.Xml.Linq;

namespace ProyectoMetodologia.Services
{
    public class TodoService
    {
        private static List<TodoItem> items = new();
        private static long nextId = 1;

        public static List<TodoItem> GetAll() => items;

        public static TodoItem? Get(long id) => items.FirstOrDefault(x => x.Id == id);

        public static TodoItem Add(TodoItem item)
        {
            item.Id = nextId++;
            items.Add(item);
            return item;
        }

        public static bool Update(long id, TodoItem item)
        {
            var index = items.FindIndex(x => x.Id == id);
            if (index == -1) return false;
            item.Id = id;
            items[index] = item;
            return true;
        }

        public static bool Delete(long id)
        {
            var item = Get(id);
            if (item == null) return false;
            items.Remove(item);
            return true;
        }
    }
}
