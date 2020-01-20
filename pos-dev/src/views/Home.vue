<template>
  <div class="home">
    <!-- Services components receives services data as a binded property -->
    <Service class="service" v-for="(service, index) of services" v-bind:key="index" v-bind:service="service"></Service>
  </div>
</template>

<script>
import Service from '@/components/Service.vue'
import axios from 'axios'

// Export a default vue component
export default {
  name: 'home',
  components: {
    Service
  },
  data: () => {
    return {
      services: []
    }
  },
  /**
   * Mounting of the view. Here, requests to backend for services
   * list is done and added to the services property. 
   */
  mounted () {
    axios.get('http://localhost:5000/api/posts')
      .then((response) => {
        for (const post of response.data) {
          this.services.push({
            name: post.title,
            inventory: Math.floor(Math.random() * (100 - 1 + 1)) + 1,
            code: Math.floor(Math.random() * (9999 - 999 + 1)) + 999,
            price: Math.floor(Math.random() * (1000 - 1 + 1)) + 1
          })
        }
      })
      .catch((error) => {
        alert(error)
      })
  }
}
</script>
<style>
.home {
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  padding: 25px;
  height: 100%;
  flex-wrap: wrap;
}

.service {
  margin: 10px;
}
</style>
