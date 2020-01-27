<template>
  <div class="home">
    <!-- Services components receives services data as a binded property -->
    <Service
      class="service"
      v-for="(service, index) of services"
      v-bind:key="index"
      v-bind:service="service"
      v-on:modal="openModal($event)"
    ></Service>
    <modal name="modal-service" :width="'60%'" :height="'65%'">
      <div class="modal-container">
        <h2 class="form-header">Datos del servicio</h2>
        <form class="modal-form">
          <div
            class="modal-body"
            v-for="(value, propertyName, index) in openedService"
            v-bind:key="index"
          >
            <label v-bind:for="propertyName">{{ propertyName }}:</label>
            <input type="text" v-bind:id="propertyName" />
          </div>
        </form>
        <div class="button-bottom">
          <button v-on:click="closeModal()">Enviar</button>
          <button class="modal-default-button" v-on:click="closeModal()">Cancelar</button>
        </div>
      </div>
    </modal>
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
      services: [],
      openedService: {},
      openModal: function (service) {
        this.openedService = service
        this.$modal.show('modal-service')
      },
      closeModal: function () {
        this.$modal.hide('modal-service')
      }
    }
  },
  /**
   * Mounting of the view. Here, requests to backend for services
   * list is done and added to the services property.
   */
  mounted () {
    axios
      .get('https://bluepos-back.herokuapp.com/api/posts')
      .then(response => {
        for (const post of response.data) {
          this.services.push({
            name: post.title,
            inventory: Math.floor(Math.random() * (100 - 1 + 1)) + 1,
            code: Math.floor(Math.random() * (9999 - 999 + 1)) + 999,
            price: Math.floor(Math.random() * (1000 - 1 + 1)) + 1
          })
        }
      })
      .catch(error => {
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

.modal-form {
  display: flex;
  flex-direction: column;
  justify-content: start;
}

.modal-container {
  overflow: scroll;
  padding: 50px;
}

.modal-header h3 {
  margin-top: 0;
  color: #42b983;
}

.modal-body {
  display: flex;
  flex-direction: column;
  margin: 20px 0;
}

.modal-default-button {
  float: right;
  align-self: flex-end;
}

input {
  height: 35px;
  font-size: 16px;
  border-radius: 5px;
  border: 1px solid black;
}

button {
  height: 40px;
  width: 125px;
  font-size: 16px;
  background-color: rgb(40, 75, 140);
  color: white;
  border-radius: 5px;
  border: none;
  cursor: pointer;
}

/*
 * The following styles are auto-applied to elements with
 * transition="modal" when their visibility is toggled
 * by Vue.js.
 *
 * You can easily play with the modal transition by editing
 * these styles.
 */

.modal-enter {
  opacity: 1;
}

.modal-leave-active {
  opacity: 1;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
</style>
