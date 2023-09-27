using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using Argon;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace uDrive.Backend.Api.Test.Integration.Abstractions
{
    public abstract class PersonRoleControllerTestBase<TController, TEntity> : AnonymousRoleControllerTestBase<TController, TEntity>
    where TController : PersonRoleController<TEntity>
    where TEntity : class, IEntity
    {
        private int _patchIndex = 1;
        private int _putIndex = 1;

        protected abstract TEntity ProvideModelValidComplete();
        protected abstract string ProvideNewRole();


        [Test]
        [Order(200)]
        public async Task POST_ValidModel_Expected_Result()
        {
            var uri = CreateUri().Build();
            var requestBody = ProvideModelValidComplete();
            using var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = JsonContent.Create(requestBody)
            };
            var response = await Client
                .SendAsync(request, HttpCompletionOption.ResponseContentRead)
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string output = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<TEntity>(output);

                newId = deserialized.Id;
            }
            await VerifyResponseAsync(HttpStatusCode.OK, response, requestBody)
                .ConfigureAwait(false);
        }


        [Test]
        [Order(201)]
        public async Task GET_All_AfterValidPOST_Expected_Result()
        => await GET_All_Expected_Result().ConfigureAwait(false);

        [Test]
        [Order(202)]
        public async Task GET_ById_AfterValidPOST_Expected_Result()
        => await GET_ById_Expected_Result().ConfigureAwait(false);

       

        //[Test]
        //[Order(304)]
        //public async Task PATCH_IndexOne_Expected_Result()
        //{
        //    var uri = CreateUri(newId).Build();
        //    var response = await Client.GetAsync(uri, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
        //    var model = await response.Content.ReadFromJsonAsync<TEntity>().ConfigureAwait(false);

        //    var updatedModel = UpdateProperty(model, ProvideRequiredProperty(), $"PATCH #{_patchIndex++}", _patchIndex);

        //    using var request = new HttpRequestMessage(HttpMethod.Patch, uri)
        //    {
        //        Content = JsonContent.Create(updatedModel)
        //    };
        //    response = await Client
        //        .SendAsync(request, HttpCompletionOption.ResponseContentRead)
        //        .ConfigureAwait(false);

        //    await VerifyResponseAsync(HttpStatusCode.NoContent, response, updatedModel)
        //        .ConfigureAwait(false);
        //}

        [Test]
        [Order(500)]
        public async Task DELETE_ById_Expected_Result()
        {
            var uri = CreateUri(newId).Build();
            var response = await Client.DeleteAsync(uri).ConfigureAwait(false);

            await VerifyResponseAsync(HttpStatusCode.NoContent, response)
                .ConfigureAwait(false);
        }

        [Test]
        [Order(501)]
        public async Task GET_All_AfterDELETE_Expected_Result()
       => await GET_All_Expected_Result().ConfigureAwait(false);

        //[SuppressMessage("Style", "IDE0270:Use coalesce expression", Justification = "As designed. MS")]
        //protected static TEntity UpdateProperty<TValue>(TEntity? model, Expression<Func<TEntity, TValue>> memberLambda, object? valueToSet, int? numericValueToSet = default)
        //{
        //    if (model is null)
        //    {
        //        throw new ArgumentNullException(nameof(model));
        //    }

        //    if (memberLambda is null)
        //    {
        //        throw new ArgumentNullException(nameof(memberLambda));
        //    }

        //    var selectedMember = memberLambda.Body as MemberExpression ?? ((UnaryExpression)memberLambda.Body).Operand as MemberExpression;

        //    if (selectedMember is null)
        //    {
        //        throw new ArgumentException("Invalid expression type. MemberExpression is expected.", nameof(memberLambda));
        //    }

        //    if (selectedMember.Member is not PropertyInfo propertyInfo)
        //    {
        //        throw new ArgumentException("Invalid member type. PropertyInfo is expected.", nameof(memberLambda));
        //    }

        //    var propertyType = propertyInfo.PropertyType;
        //    if (valueToSet is null && !propertyType.IsReferenceOrNullableType())
        //    {
        //        Assert.Inconclusive("Test not relevant, since property is not a reference or nullable type.");
        //    }

        //    if (propertyType != typeof(string) && numericValueToSet.HasValue)
        //    {
        //        if (propertyType == typeof(DateTime))
        //        {
        //            propertyInfo.SetValue(model, new DateTime(2024, 1, numericValueToSet.Value, 0, 0, 0, DateTimeKind.Utc));
        //        }
        //        else
        //        {
        //            propertyInfo.SetValue(model, Convert.ChangeType(numericValueToSet.Value - 1, propertyType, null), null);
        //        }
        //    }
        //    else
        //    {
        //        propertyInfo.SetValue(model, valueToSet, null);
        //    }

        //    return model;
        //}
        //protected abstract Expression<Func<TEntity, object>> ProvideRequiredProperty();

    }
}
