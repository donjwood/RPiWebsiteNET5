import Vue from 'vue'
import Vuelidate from 'vuelidate';
import LoginApp from './components/Login.vue'

Vue.use(Vuelidate);

Vue.config.productionTip = false;

new Vue({
  render: h => h(LoginApp),
}).$mount('#loginApp')
