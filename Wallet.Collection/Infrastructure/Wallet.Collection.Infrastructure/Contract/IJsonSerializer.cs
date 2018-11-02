namespace Wallet.Collection.Infrastructure.Contract
{
    public interface IJsonSerializer
    {
        /// <summary>
        /// object tipli sınıfı json string döner
        /// </summary>
        string JsonSerialize(dynamic source, int maxDepth, int nullValueHandling = 0);

        /// <summary>
        /// object tipli sınıfı json string döner
        /// </summary>
        string JsonSerialize(dynamic source, bool applyFormatting = true);

        /// <summary>
        /// json string object çevirir
        /// </summary>
        T JsonDeserialize<T>(string source, int nullValueHandling = 0);
         
    }
}
