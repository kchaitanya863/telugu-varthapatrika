using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DataSource8DataSource : IDataSource<RssSchema>
    {
        private const string _url =  @"http://www.teluguwishesh.com/home/226-ladies-special.feed";

        private IEnumerable<RssSchema> _data = null;

        public DataSource8DataSource()
        {
        }

        public async Task<IEnumerable<RssSchema>> LoadData()
        {
            if (_data == null)
            {
                try
                {
                    var rssDataProvider = new RssDataProvider(_url);
                    _data = await rssDataProvider.Load();
                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("DataSource8DataSourceDataSource.LoadData", ex.ToString());
                }
            }
            return _data;
        }

        public async Task<IEnumerable<RssSchema>> Refresh()
        {
            _data = null;
            return await LoadData();
        }
    }
}
