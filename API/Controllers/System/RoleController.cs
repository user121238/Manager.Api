﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Filters;
using API.ViewModel;
using Common.Enum;
using Common.Language;
using IBLL.System;
using Microsoft.Extensions.Localization;
using Models.System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.System
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IStringLocalizer _localizer;
        private readonly IRoleInfoBLl _roleInfoBll;
        public RoleController(IStringLocalizer<Language> localizer, IRoleInfoBLl roleInfoBll)
        {
            _localizer = localizer;
            _roleInfoBll = roleInfoBll;
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetRoleInfo)), Action("System.Role")]
        public async Task<ResponseResult<TableData<RoleInfo>>> GetRoleInfo(int page, int limit, string roleName)
        {
            var result = new ResponseResult<TableData<RoleInfo>>();
            roleName ??= "";
            var list = await _roleInfoBll.GetPageListAsync(page, limit, out var totalCount, c => c.IsDelete == 0 && c.RoleName.Contains(roleName),
                c => c.Id, true);

            result.Code = ResponseStatusEnum.Ok;
            result.Msg = "";
            result.Data = new TableData<RoleInfo>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                List = list

            };

            return result;

        }


        /// <summary>
        /// 移除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(nameof(Remove)), Action("System.Role.Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var role = await _roleInfoBll.GetListAsync(c => c.Id == id);
            if (!role.Any()) return NotFound(_localizer["NotFonund"]);
            var temp = role[0];
            temp.IsDelete = DeleteStatus.Delete;
            temp.RoleStatus = EnableEnum.Disable;
            temp.EditTime = DateTime.Now;
            return await _roleInfoBll.EditAsync(temp)
                ? (IActionResult)Ok(_localizer["OK"])
                : BadRequest(_localizer["BadRequest"]);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(nameof(AddRole)), Action("System.Role.Add")]
        public async Task<IActionResult> AddRole([FromForm] RoleInfo model)
        {
            return await _roleInfoBll.AddAsync(model) ? (IActionResult)BadRequest(_localizer["BadRequest"]) : Ok(_localizer["OK"]);
        }


        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(nameof(EditRole)), Action("System.Role.Edit")]
        public async Task<IActionResult> EditRole([FromForm] RoleInfo model)
        {
            var temp = await _roleInfoBll.GetListAsync(c => c.Id == model.Id);
            if (!temp.Any()) return NotFound(_localizer["NotFound"]);
            temp[0].RoleName = model.RoleName;
            temp[0].EditTime = DateTime.Now;

            return await _roleInfoBll.EditAsync(temp[0])
                ? (IActionResult)Ok(_localizer["OK"])
                : BadRequest(_localizer["BadRequest"]);
        }

        /// <summary>
        /// 设置角色状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleStatus"></param>
        /// <returns></returns>
        [HttpGet(nameof(SetRoleStatus)), Action("System.Role.SetRoleStatus")]
        public async Task<IActionResult> SetRoleStatus(int id, EnableEnum roleStatus)
        {
            var role = await _roleInfoBll.GetListAsync(c => c.Id == id);
            if (!role.Any()) return NotFound(_localizer["NotFound"]);
            role[0].RoleStatus = roleStatus;
            role[0].EditTime = DateTime.Now;

            return await _roleInfoBll.EditAsync(role[0])
                ? (IActionResult)Ok(_localizer["OK"])
                : BadRequest(_localizer["BadRequest"]);
        }


        /// <summary>
        /// 获取所有未删除的角色
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllRole)), Action("System.Role.GetAllRole")]
        public async Task<List<RoleInfo>> GetAllRole()
        {
            var role = await _roleInfoBll.GetListAsync(c => c.IsDelete == DeleteStatus.NoDelete && c.RoleStatus == EnableEnum.Enable);
            return role;
        }



    }
}
