global using System.Data;
global using Microsoft.EntityFrameworkCore;
global using System.Security.Claims;
global using System.ComponentModel.DataAnnotations;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.Cookies;
global using Microsoft.AspNetCore.Authorization;

global using PharmaFLow.DataAccess.Abstracts.IRepositories;
global using ComputerShop.DataAccess.Repositories;

global using PharmaFlow.Web.Areas.Identity.ViewModels;
global using PharmaFlow.Infrastructure.Dtos.Enumerations.Users;
global using PharmaFlow.Web.ViewModels.Enumerations.Users;
global using PharmaFlow.Web.ViewModels;
global using PharmaFlow.Infrastructure.Dtos;
global using PharmaFlow.Web.Extensions;
global using PharmaFlow.Infrastructure.Dtos.Requests;

global using PharmaFlow.Utils;
