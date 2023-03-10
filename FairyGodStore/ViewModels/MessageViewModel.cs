using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.ViewModels
{
    public class MessageViewModel
    {
        public static KeyValuePair<string, string> LOGIN_SUCCESS = new KeyValuePair<string, string>("001", "Đăng nhập thành công");
        public static KeyValuePair<string, string> LOGIN_FAIL = new KeyValuePair<string, string>("002", "Sai thông tin đăng nhập");
        public static KeyValuePair<string, string> DATA_EMPTY = new KeyValuePair<string, string>("003", "Không có dữ liệu");

    }
}
