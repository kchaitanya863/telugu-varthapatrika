using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DataSource2DataSource : IDataSource<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Section",
                Title = "మూవీ గోస్సిప్స్",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section3Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "క్రీడలు",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section4Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "వ్యాపారం",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section5Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "ఆణిముత్యాలు",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section6Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "సినిమా రివ్యూస్",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section7Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "లేడీస్ స్పెషల్",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section8Page",
            },
            new MenuSchema
            {
                Type = "Section",
                Title = "స్టార్ డైరీ",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "Section9Page",
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
