using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DataSource10DataSource : IDataSource<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Section",
                Title = "న్యాయ సలహాలు",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section11Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "బ్యూటీ టిప్స్",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section12Page",
            },
		};

        public async Task<IEnumerable<MenuSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<MenuSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
