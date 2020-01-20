<template>
  <div class="home">
    <Service class="service" v-for="(service, index) of services" v-bind:key="index" v-bind:service="service"></Service>
  </div>
</template>

<script>
// @ is an alias to /src
import Service from '@/components/Service.vue'
import axios from 'axios'

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
  mounted () {
    axios.get('https://jsonplaceholder.typicode.com/posts')
      .then((response) => {
        for (const post of response.data) {
          this.services.push({
            name: post.title,
            inventory: Math.floor(Math.random() * (100 - 1 + 1)) + 1,
            code: Math.floor(Math.random() * (9999 - 999 + 1)) + 999,
            price: Math.floor(Math.random() * (1000 - 1 + 1)) + 1
          })
        }
        // this.services = [...response.data].slice(0, 20)
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
