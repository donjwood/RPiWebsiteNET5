(function(e){function s(s){for(var t,l,o=s[0],n=s[1],m=s[2],u=0,d=[];u<o.length;u++)l=o[u],Object.prototype.hasOwnProperty.call(r,l)&&r[l]&&d.push(r[l][0]),r[l]=0;for(t in n)Object.prototype.hasOwnProperty.call(n,t)&&(e[t]=n[t]);c&&c(s);while(d.length)d.shift()();return i.push.apply(i,m||[]),a()}function a(){for(var e,s=0;s<i.length;s++){for(var a=i[s],t=!0,o=1;o<a.length;o++){var n=a[o];0!==r[n]&&(t=!1)}t&&(i.splice(s--,1),e=l(l.s=a[0]))}return e}var t={},r={editUser:0},i=[];function l(s){if(t[s])return t[s].exports;var a=t[s]={i:s,l:!1,exports:{}};return e[s].call(a.exports,a,a.exports,l),a.l=!0,a.exports}l.m=e,l.c=t,l.d=function(e,s,a){l.o(e,s)||Object.defineProperty(e,s,{enumerable:!0,get:a})},l.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},l.t=function(e,s){if(1&s&&(e=l(e)),8&s)return e;if(4&s&&"object"===typeof e&&e&&e.__esModule)return e;var a=Object.create(null);if(l.r(a),Object.defineProperty(a,"default",{enumerable:!0,value:e}),2&s&&"string"!=typeof e)for(var t in e)l.d(a,t,function(s){return e[s]}.bind(null,t));return a},l.n=function(e){var s=e&&e.__esModule?function(){return e["default"]}:function(){return e};return l.d(s,"a",s),s},l.o=function(e,s){return Object.prototype.hasOwnProperty.call(e,s)},l.p="/";var o=window["webpackJsonp"]=window["webpackJsonp"]||[],n=o.push.bind(o);o.push=s,o=o.slice();for(var m=0;m<o.length;m++)s(o[m]);var c=n;i.push([1,"chunk-vendors"]),a()})({1:function(e,s,a){e.exports=a("a0ad")},a0ad:function(e,s,a){"use strict";a.r(s);a("e260"),a("e6cf"),a("cca6"),a("a79d");var t=a("2b0e"),r=a("1dce"),i=a.n(r),l=function(){var e=this,s=e.$createElement,a=e._self._c||s;return a("div",[a("div",{directives:[{name:"show",rawName:"v-show",value:e.successfullyUpdated&&e.showSuccessMessage,expression:"successfullyUpdated && showSuccessMessage"}],staticClass:"row"},[a("div",{staticClass:"col-12"},[a("b-alert",{attrs:{show:"",variant:"success"}},[a("i",{staticClass:"fas fa-check"}),e._v(" Successfully submitted user changes. ")])],1)]),a("div",{directives:[{name:"show",rawName:"v-show",value:e.errorMessage,expression:"errorMessage"}],staticClass:"row"},[a("div",{staticClass:"col-12"},[a("div",{staticClass:"alert alert-danger",attrs:{role:"alert"}},[a("i",{staticClass:"fas fa-exclamation-triangle"}),e._v(" "+e._s(e.errorMessage)+" ")])])]),a("div",{directives:[{name:"show",rawName:"v-show",value:!e.successfullyUpdated||!e.showSuccessMessage,expression:"!successfullyUpdated || !showSuccessMessage"}]},[a("div",{staticClass:"form-group row"},[a("label",{staticClass:"col-lg-3 col-xl-2 col-form-label",attrs:{for:"txtFirstName"}},[e._v(" First Name "),e.$v.firstName.$error?a("span",{staticClass:"error-asterisk"},[e._v("*")]):e._e()]),a("div",{staticClass:"col-lg-9 col-xl-10"},[a("input",{directives:[{name:"model",rawName:"v-model",value:e.firstName,expression:"firstName"}],staticClass:"form-control",class:{"invalid-field":e.$v.firstName.$error},attrs:{type:"text",name:"txtFirstName"},domProps:{value:e.firstName},on:{input:function(s){s.target.composing||(e.firstName=s.target.value)}}})]),a("div",{staticClass:"offset-lg-3 offset-xl-2 col-lg-9 col-xl-10 field-error-message"},[e.$v.firstName.$error&&!e.$v.firstName.required?a("span",[e._v("First name is required.")]):e._e()])]),a("div",{staticClass:"form-group row"},[a("label",{staticClass:"col-lg-3 col-xl-2 col-form-label",attrs:{for:"txtMiddleName"}},[e._v(" Middle Name ")]),a("div",{staticClass:"col-lg-9 col-xl-10"},[a("input",{directives:[{name:"model",rawName:"v-model",value:e.middleName,expression:"middleName"}],staticClass:"form-control",attrs:{type:"text",name:"txtMiddleName"},domProps:{value:e.middleName},on:{input:function(s){s.target.composing||(e.middleName=s.target.value)}}})])]),a("div",{staticClass:"form-group row"},[a("label",{staticClass:"col-lg-3 col-xl-2 col-form-label",attrs:{for:"txtLastName"}},[e._v(" Last Name "),e.$v.lastName.$error?a("span",{staticClass:"error-asterisk"},[e._v("*")]):e._e()]),a("div",{staticClass:"col-lg-9 col-xl-10"},[a("input",{directives:[{name:"model",rawName:"v-model",value:e.lastName,expression:"lastName"}],staticClass:"form-control",class:{"invalid-field":e.$v.lastName.$error},attrs:{type:"text",name:"txtLastName"},domProps:{value:e.lastName},on:{input:function(s){s.target.composing||(e.lastName=s.target.value)}}})]),a("div",{staticClass:"offset-lg-3 offset-xl-2 col-lg-9 col-xl-10 field-error-message"},[e.$v.lastName.$error&&!e.$v.lastName.required?a("span",[e._v("Last name is required.")]):e._e()])]),a("div",{staticClass:"form-group row"},[a("label",{staticClass:"col-lg-3 col-xl-2 col-form-label",attrs:{for:"txtEmail"}},[e._v(" Email "),e.$v.email.$error?a("span",{staticClass:"error-asterisk"},[e._v("*")]):e._e()]),a("div",{staticClass:"col-lg-9 col-xl-10"},[a("input",{directives:[{name:"model",rawName:"v-model",value:e.email,expression:"email"}],staticClass:"form-control",class:{"invalid-field":e.$v.email.$error},attrs:{type:"email",name:"txtEmail"},domProps:{value:e.email},on:{input:function(s){s.target.composing||(e.email=s.target.value)}}})]),a("div",{staticClass:"offset-lg-3 offset-xl-2 col-lg-9 col-xl-10 field-error-message"},[e.$v.email.$error&&!e.$v.email.required?a("span",[e._v("Email is required.")]):e._e()])]),a("div",{directives:[{name:"show",rawName:"v-show",value:"admin"!=e.userName,expression:"userName != 'admin'"}],staticClass:"form-group row"},[a("div",{staticClass:"offset-lg-3 offset-xl-2 col-lg-9 col-xl-10"},[a("div",{staticClass:"form-check"},[a("input",{directives:[{name:"model",rawName:"v-model",value:e.useEmailAsUserName,expression:"useEmailAsUserName"}],staticClass:"form-check-input",attrs:{type:"checkbox",id:"chkUseEmailAsUserName",name:"chkUseEmailAsUserName"},domProps:{checked:Array.isArray(e.useEmailAsUserName)?e._i(e.useEmailAsUserName,null)>-1:e.useEmailAsUserName},on:{change:function(s){var a=e.useEmailAsUserName,t=s.target,r=!!t.checked;if(Array.isArray(a)){var i=null,l=e._i(a,i);t.checked?l<0&&(e.useEmailAsUserName=a.concat([i])):l>-1&&(e.useEmailAsUserName=a.slice(0,l).concat(a.slice(l+1)))}else e.useEmailAsUserName=r}}}),a("label",{staticClass:"form-check-label",attrs:{for:"chkUseEmailAsUserName"}},[e._v(" Use email address as username. ")])])])]),a("div",{staticClass:"form-group row"},[a("label",{staticClass:"col-lg-3 col-xl-2 col-form-label",attrs:{for:"txtUsername"}},[e._v(" Username "),a("span",{directives:[{name:"show",rawName:"v-show",value:e.$v.userName.$error,expression:"$v.userName.$error"}],staticClass:"error-asterisk"},[e._v("*")])]),a("div",{staticClass:"col-lg-9 col-xl-10"},[a("div",{staticClass:"input-group"},[a("input",{directives:[{name:"model",rawName:"v-model",value:e.userName,expression:"userName"}],staticClass:"form-control",class:{"invalid-field":e.$v.userName.$error},attrs:{type:"text",name:"txtUserName",disabled:"admin"==e.userName||e.useEmailAsUserName},domProps:{value:e.userName},on:{input:function(s){s.target.composing||(e.userName=s.target.value)}}}),a("div",{staticClass:"input-group-append"},[a("span",{staticClass:"input-group-text"},[e.$v.userName.required?e.$v.$pending?a("span",[a("i",{staticClass:"fas fa-cog fa-spin"})]):e.$v.userName.isUserNameAvailable?a("span",{staticStyle:{color:"green"}},[a("i",{staticClass:"fas fa-check-circle"})]):a("span",{staticStyle:{color:"red"}},[a("i",{staticClass:"fas fa-times-circle"})]):a("span",[a("i",{staticClass:"fas fa-cog"})])])])])]),a("div",{staticClass:"offset-lg-3 offset-xl-2 col-lg-9 col-xl-10",staticStyle:{height:"15px"}},[e.$v.userName.$error&&!e.$v.userName.required?a("span",{staticClass:"field-error-message"},[e._v("Username is required.")]):e.$v.$pending||e.$v.userName.isUserNameAvailable?!e.$v.$pending&&e.$v.userName.required&&e.$v.userName.isUserNameAvailable?a("span",{staticClass:"field-valid-message"},[e._v("Username is available.")]):e._e():a("span",{staticClass:"field-error-message"},[e._v("Username is unavailable.")])])]),a("div",{directives:[{name:"show",rawName:"v-show",value:e.enableChangeAdmin,expression:"enableChangeAdmin"}],staticClass:"form-group row"},[a("div",{staticClass:"offset-lg-3 offset-xl-2 col-lg-9 col-xl-10"},[a("div",{staticClass:"form-check"},[a("input",{directives:[{name:"model",rawName:"v-model",value:e.isAdmin,expression:"isAdmin"}],staticClass:"form-check-input",attrs:{type:"checkbox",id:"chkIsAdmin",name:"chkIsAdmin"},domProps:{checked:Array.isArray(e.isAdmin)?e._i(e.isAdmin,null)>-1:e.isAdmin},on:{change:function(s){var a=e.isAdmin,t=s.target,r=!!t.checked;if(Array.isArray(a)){var i=null,l=e._i(a,i);t.checked?l<0&&(e.isAdmin=a.concat([i])):l>-1&&(e.isAdmin=a.slice(0,l).concat(a.slice(l+1)))}else e.isAdmin=r}}}),a("label",{staticClass:"form-check-label",attrs:{for:"chkIsAdmin"}},[e._v(" This user is an admin. ")])])])]),a("div",{staticClass:"form-group row"},[a("div",{staticClass:"col-12 text-center"},[a("button",{staticClass:"btn btn-primary",attrs:{type:"button"},on:{click:e.submitForm}},[a("i",{staticClass:"fas fa-user-edit"}),e._v(" Update")])])])])])},o=[],n=(a("96cf"),a("1da1")),m=a("b5ae"),c=a("bc3a"),u=a.n(c),d=JSON.parse(document.getElementById("JsonUserRecord").value),v=document.getElementsByName("__RequestVerificationToken")[0].value,f={name:"editUserApp",data:function(){return{user:d,loggedInUser:"",id:d.ID,firstName:d.FirstName,middleName:d.MiddleName,lastName:d.LastName,email:d.Email,isAdmin:d.IsAdmin,useEmailAsUserName:!0,userName:d.UserName,successfullyUpdated:!1,errorMessage:""}},created:function(){this.useEmailAsUserName=this.userName==this.email&&"admin"!=this.userName},validations:{firstName:{required:m["required"]},lastName:{required:m["required"]},email:{required:m["required"],email:m["email"]},userName:{required:m["required"],isUserNameAvailable:function(e){var s=this;return Object(n["a"])(regeneratorRuntime.mark((function a(){var t;return regeneratorRuntime.wrap((function(a){while(1)switch(a.prev=a.next){case 0:if(""!=e){a.next=2;break}return a.abrupt("return",!0);case 2:return a.prev=2,u.a.defaults.headers.common["RequestVerificationToken"]=v,a.next=6,u.a.post("/Users/Edit?handler=IsUsernameAvailable",{UserName:s.userName});case 6:return t=a.sent,a.abrupt("return",t.data.isUserNameAvaliable);case 10:a.prev=10,a.t0=a["catch"](2),console.log(a.t0);case 13:case"end":return a.stop()}}),a,null,[[2,10]])})))()}}},watch:{email:function(){this.useEmailAsUserName&&(this.userName=this.email)},useEmailAsUserName:function(){this.useEmailAsUserName&&(this.userName=this.email)}},computed:{enableChangeAdmin:function(){return"admin"!=this.userName&&this.loggedInUser.id!=this.id}},methods:{submitForm:function(){var e=Object(n["a"])(regeneratorRuntime.mark((function e(){var s;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:if(this.errorMessage="",this.$v.$touch(),this.$v.$anyError){e.next=14;break}return e.prev=3,e.next=6,u.a.patch("/userapi/users/"+this.user.id,{firstName:this.firstName,middleName:this.middleName,lastName:this.lastName,email:this.email,userName:this.userName,isAdmin:this.isAdmin});case 6:s=e.sent,s.data.errorMessage?this.errorMessage=s.data.errorMessage:(this.successfullyUpdated=!0,this.$emit("user-updated",{id:this.user.id,firstName:this.firstName,middleName:this.middleName,lastName:this.lastName,email:this.email,userName:this.userName,isAdmin:this.isAdmin})),e.next=14;break;case 10:e.prev=10,e.t0=e["catch"](3),console.log(e.t0),this.errorMessage=e.t0;case 14:case"end":return e.stop()}}),e,this,[[3,10]])})));function s(){return e.apply(this,arguments)}return s}()}},p=f,N=a("2877"),h=Object(N["a"])(p,l,o,!1,null,null,null),g=h.exports;t["a"].use(i.a),new t["a"]({render:function(e){return e(g)}}).$mount("#editUserApp")}});
//# sourceMappingURL=editUser.js.map