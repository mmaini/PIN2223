using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoBlazorCoreHosted.Shared;

namespace ToDoBlazorCoreHosted.Client.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; }

        private List<ToDoItem> tasks;
        private string error;
        private string newTodo;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string requestUri = "ToDoItem";
                tasks = await Http.GetFromJsonAsync<List<ToDoItem>>(requestUri);

            }
            catch (Exception ex)
            {
                error = "Došlo je do greške";
            }
        }

        private async Task CheckBoxChecked(ToDoItem task)
        {
            task.IsDone = !task.IsDone;
            string requestUri = $"ToDoItem/{task.Id}";
            var response = await Http.PutAsJsonAsync<ToDoItem>(requestUri, task);
            if(!response.IsSuccessStatusCode)
            {
                error = response.ReasonPhrase;
            }
        }

        private async Task DeleteTask(ToDoItem task)
        {
            tasks.Remove(task);
            string requestUri = $"ToDoItem/{task.Id}";
            var response = await Http.DeleteAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                error = response.ReasonPhrase;
            }
        }


        private async Task AddTask()
        {
            if(!string.IsNullOrWhiteSpace(newTodo))
            {
                ToDoItem newTaskItem = new ToDoItem
                {
                    Title = newTodo,
                    IsDone = false
                };

                tasks.Add(newTaskItem);
                string requestUri = "ToDoItem";
                var response = await Http.PostAsJsonAsync(requestUri, newTaskItem);
                if (response.IsSuccessStatusCode)
                {
                    newTodo = string.Empty;
                }
                else
                {
                    error = response.ReasonPhrase;
                }
            }

           
        }
    }
}
