import Vue from 'vue'
import Vuelidate from 'vuelidate';
import EditUser from './components/EditUser.vue'

Vue.use(Vuelidate);

//Vue.config.productionTip = false;

new Vue({
  render: h => h(EditUser),
}).$mount('#editUserApp');
