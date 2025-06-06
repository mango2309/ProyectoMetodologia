using ProyectoMetodologia.Models;
using ProyectoMetodologia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApiTests
{
    public class TodoServiceTests
    {
        [Fact]
        public void Add_Item_Should_Increment_List()
        {
            var item = new TodoItem { Title = "Test Task", IsComplete = false };
            var result = TodoService.Add(item);

            Assert.NotNull(result);
            Assert.Equal("Test Task", result.Title);
        }
        //PRUEBA TEST
    }
}
