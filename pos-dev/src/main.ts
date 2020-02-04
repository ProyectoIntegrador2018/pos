import Vue from 'vue'
import VModal from 'vue-js-modal'
import App from './App.vue'
import router from './router'

import VueToastr from 'vue-toastr'

Vue.use(VModal)
Vue.config.productionTip = false
Vue.use(VueToastr, {
  defaultStyle: { 'fontFamily': 'Avenir, Helvetica, Arial, sans-serif;' }
})

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
