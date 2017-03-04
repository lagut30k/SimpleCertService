using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using SimpleCertService.Bussiness.ViewModels;

namespace SimpleCertService.Bussiness.Helpers
{
    public class CSPHelper
    {
        public static IEnumerable<CSPDto> ReadAllProviders()
        {
            return ReadProviderNames().Join(
                ReadProviderTypeNames(),
                provider => provider.Item2,
                providerType => providerType.Item2,
                (providerName, providerType) => new CSPDto { Name = providerName.Item1, TypeName = providerType.Item1 }
            );
        }

        private static IEnumerable<Tuple<string, int>> ReadProviderNames()
        {
            var installedCSPs = new List<Tuple<string, int>>();
            int cbName = 0;
            int dwType = 1;
            int dwIndex = 0;
            while (CryptEnumProviders(dwIndex, IntPtr.Zero, 0, ref dwType, null, ref cbName))
            {
                var psbName = new StringBuilder(cbName);
                if (CryptEnumProviders(dwIndex++, IntPtr.Zero, 0, ref dwType, psbName, ref cbName))
                {
                    installedCSPs.Add(Tuple.Create(psbName.ToString(), dwType));
                }
            }
            return installedCSPs;
        }

        private static IEnumerable<Tuple<string, int>> ReadProviderTypeNames()
        {
            var installedCSPTypes = new List<Tuple<string, int>>();
            int cbTypeName = 0;
            int dwType = 1;
            int dwIndex = 0;
            while (CryptEnumProviderTypes(dwIndex, IntPtr.Zero, 0, ref dwType, null, ref cbTypeName))
            {
                var psbTypeName = new StringBuilder(cbTypeName);
                if (CryptEnumProviderTypes(dwIndex++, IntPtr.Zero, 0, ref dwType, psbTypeName, ref cbTypeName))
                {
                    installedCSPTypes.Add(Tuple.Create(psbTypeName.ToString(), dwType));
                }
            }
            return installedCSPTypes;
        }

        [DllImport("advapi32.dll")]
        private static extern bool CryptEnumProviders(
            int dwIndex,
            IntPtr pdwReserved,
            int dwFlags,
            ref int pdwProvType,
            StringBuilder pszProvName,
            ref int pcbProvName);

        [DllImport("advapi32.dll")]
        private static extern bool CryptEnumProviderTypes(
            int dwIndex,
            IntPtr pdwReserved,
            int dwFlags,
            ref int pdwProvType,
            StringBuilder pszTypeName,
            ref int pcbProvTypeName);
    }
}
