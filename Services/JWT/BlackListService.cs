namespace ApiProject.Services.JWT
{
    public interface IBlackListService
    {
        void AddToBlacklist(string token);
        bool IsTokenBlacklisted(string token);
        public void RemoveFromBlacklist(string jtiClaim);
        // Additional methods or properties as needed
    }

    // This can be refreshed with same token refresh time or twice the time. For memory fixation.
    public class InMemoryBlacklistService : IBlackListService
    {
        private readonly HashSet<string> _blacklistedTokens = new HashSet<string>();

        // Add jwt jti
        public void AddToBlacklist(string token)
        {
            _blacklistedTokens.Add(token);
        }

        public bool IsTokenBlacklisted(string token)
        {
            return _blacklistedTokens.Contains(token);
        }
        public void RemoveFromBlacklist(string jtiClaim)
        {
            _blacklistedTokens.Remove(jtiClaim);
        }
    }
}
