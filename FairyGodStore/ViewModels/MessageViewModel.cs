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
        public static KeyValuePair<string, string> LOGOUT_SUCCESS = new KeyValuePair<string, string>("004", "Đăng xuất thành công");
        public static KeyValuePair<string, string> LOGOUT_FAIL = new KeyValuePair<string, string>("005", "Đăng xuất thất bại");
        public static KeyValuePair<string, string> AUTHEN = new KeyValuePair<string, string>("006", "Chức năng cần đăng nhập");
        public static KeyValuePair<string, string> SYSTEM_ERROR(string errMess = "")
        {
            if(!errMess.IsEmpty())
                return new KeyValuePair<string, string>("010", errMess);
            return new KeyValuePair<string, string>("010", "Lỗi hệ thống");
        }
        public static KeyValuePair<string, string> DATA_VALID(string errMess = "")
        {
            if (!errMess.IsEmpty())
                return new KeyValuePair<string, string>("007", errMess);
            return new KeyValuePair<string, string>("007", "Dữ liệu đầu vào không đúng");
        }
    }
}
