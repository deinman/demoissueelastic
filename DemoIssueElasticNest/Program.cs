using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Nest.JsonNetSerializer;

DefaultJsonNetSerializer();
DefaultJsonNetSerializerUnsugared();

Console.WriteLine("Hello, World!");
return;

void DefaultJsonNetSerializer()
{
    var pool = new SingleNodePool(new Uri("http://localhost:9200"));
    var connectionSettings =
        new ElasticsearchClientSettings(pool, sourceSerializer: JsonNetSerializer.Default);
    var client = new ElasticsearchClient(connectionSettings);
}

void DefaultJsonNetSerializerUnsugared()
{
    var pool = new SingleNodePool(new Uri("http://localhost:9200"));
    var connectionSettings = new ElasticsearchClientSettings(
        pool,
        sourceSerializer: (builtin, settings) => new JsonNetSerializer(builtin, settings));
    var client = new ElasticsearchClient(connectionSettings);
}