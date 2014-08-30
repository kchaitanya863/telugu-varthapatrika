using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DataSource3DataSource : IDataSource<RssSchema>
    {
        private const string _url =  @"http://www.teluguwishesh.com/home/244-movie-gossips.feed";

        private IEnumerable<RssSchema> _data = null;

        public DataSource3DataSource()
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
                    AppLogs.WriteError("DataSource3DataSourceDataSource.LoadData", ex.ToString());
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
