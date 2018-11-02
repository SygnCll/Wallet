using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Collection.Infrastructure.Enums
{
    public enum ServiceResponseCode
    {
        /// <summary>
        /// Transaction completed successfully.
        /// </summary>
        RM0000,
        /// <summary>
        /// Technical problem. Please try again.
        /// </summary>
        RM0001,
        /// <summary>
        /// Technical problem. Please try again.
        /// </summary>
        RM0002,
        /// <summary>
        /// User already exist.
        /// </summary>
        USR0001,
        /// <summary>
        /// User not found.
        /// </summary>
        USR0002,
        /// <summary>
        /// 
        /// </summary>
        USR0003,
        /// <summary>
        /// 
        /// </summary>
        USR0004,
        /// <summary>
        /// 
        /// </summary>
        USR0005,
        /// <summary>
        /// Invalid user or password.
        /// </summary>
        USR0006,
        /// <summary>
        /// Password error.
        /// </summary>
        USR0007,
        /// <summary>
        /// User has been blocked.
        /// </summary>
        USR0008,
        /// <summary>
        /// User is passive.
        /// </summary>
        USR0009
    }
}
