using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan JwtTokenLifetime { get; set; }
        public TimeSpan RefreshTokenLifetime { get; set; }

        public byte[] SecretBytes => Encoding.UTF8.GetBytes(Secret);
    }
}
