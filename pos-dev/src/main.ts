import Vue from 'vue'
<<<<<<< HEAD
import App from './App.vue'
import router from './router'

=======
import VModal from 'vue-js-modal'
import App from './App.vue'
import router from './router'

Vue.use(VModal)
>>>>>>> 73544c4897b9f0899aff78a7aff2611407d46f73
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
