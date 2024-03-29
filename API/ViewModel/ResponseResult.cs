﻿using Common.Enum;

namespace API.ViewModel
{
    public class ResponseResult<T>
    {
        /// <summary>
        /// 请求结果代码
        /// </summary>
        public ResponseStatusEnum Code { get; set; } = ResponseStatusEnum.BadRequest;



        /// <summary>
        /// 请求出错时的出错信息
        /// </summary>
        public string Msg { get; set; } = "请求错误";

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
}
