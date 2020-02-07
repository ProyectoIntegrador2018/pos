<template>
  <div class="main-container">
    <div class="header">
      <img src="../../assets/logo-white.svg" class="logo">
    </div>
    <div class="home">
      <!-- Services components receives services data as a binded property -->
      <div class="services-container">
        <div class="services">
          <Service
            class="service"
            v-for="(service, index) of services"
            v-bind:key="index"
            v-bind:service="service"
            v-on:modal="openModal($event)"
          ></Service>
        </div>
      </div>
      <Cart v-bind:items="items" v-on:remove="removeItem($event)" v-on:cancel="cancelCart()" v-on:pay="payCart()"/>
      <modal name="modal-service" :width="'60%'" :height="'65%'">
        <div class="modal-container">
          <h2 class="form-header">Datos del servicio</h2>
          <form class="modal-form">
            <div
              class="modal-body"
              v-for="(data, index) in openedService.modalData"
              v-bind:key="index"
            >
              <label v-bind:for="data.field">{{ data.field }}:</label>
              <input v-bind:type="data.type" v-bind:id="data.field" v-bind:value="data.default" v-model="values[index]" />
            </div>
          </form>
          <div class="button-bottom">
            <button v-on:click="sendModal()">Enviar</button>
            <button class="modal-default-button" v-on:click="closeModal()">Cancelar</button>
          </div>
        </div>
      </modal>
    </div>
  </div>
</template>

<script>
import Service from '@/components/Service.vue'
import Cart from '@/components/Cart.vue'
import axios from 'axios'

// Export a default vue component
export default {
  name: 'home',
  components: {
    Service,
    Cart
  },
  data: () => {
    return {
      services: [],
      openedService: {},
      items: [],
      currentValue: null,
      values: [null, null, 0],
      url: 'https://bluepos-back.herokuapp.com/api',
      openModal: function (service) {
        this.openedService = service
        this.values[2] = this.openedService.price
        this.$modal.show('modal-service')
      },
      closeModal: function () {
        this.$modal.hide('modal-service')
      },
      sendModal: function () {
        this.items.push({
          qty: 1,
          name: this.openedService.name,
          value: this.values[2],
          email: this.values[0],
          phone: this.values[1],
          amount: Number(this.values[2])
        })
        this.values[0] = null
        this.values[1] = null
        this.values[2] = this.openedService.price
        this.$toastr.s('Success', '')
        this.$modal.hide('modal-service')
      },
      removeItem: function (event) {
        // this process canceled payments. The client requested for it to be removed.
        this.items.splice(event.index, 1)
      },
      cancelCart () {
        // this process canceled payments. The client requested for it to be removed.
        // for (let i = 0; i < this.items.length; i++) {
        //   axios
        //     .delete(`${this.url}/transactions/${this.items[i].id}`)
        //     .then(response => {
        //       this.$toastr.s('Success', response.data.ResponseDescription)
        //     })
        //     .catch(error => {
        //       this.$toastr.e('Error', error)
        //     })
        // }
        this.items = []
      },
      payCart () {
        if (this.items.length > 0) {
          for (let index = 0; index < this.items.length; index++) {
            axios
              .post(`${this.url}/transactions`, {
                ProductCode: this.items[index].code,
                Amount: this.items[index].amount,
                Email: this.items[index].email,
                PhoneNumber: this.items[index].phone
              })
              .then(response => {
                if (response.data.ResponseCode === '999') {
                  this.$toastr.e('Error', response.data.ResponseDescription)
                  return
                }
                this.$toastr.s('Success', response.data.ResponseDescription)
                this.$modal.hide('modal-service')
              })
              .catch(error => {
                this.$toastr.e('Error', error)
              })
          }
          this.$toastr.s('Artículos cobrados', 'Success')
          this.items = []
        } else {
          this.$toastr.e('No hay artículos en el carrito actual', 'Error')
        }
      }
    }
  },
  /**
   * Mounting of the view. Here, requests to backend for services
   * list is done and added to the services property.
   */
  mounted () {
    axios
      .get(`${this.url}/products`)
      .then(response => {
        for (let index = 0; index < response.data.ServiceList.ServiceID.length; index++) {
          this.services.push({
            name: response.data.ServiceList.ServiceName[index],
            id: response.data.ServiceList.ServiceID[index],
            code: response.data.ServiceList.ServiceCode[index],
            price: response.data.ServiceList.MaxAmount[index],
            modalData: [
              {
                field: 'Correo electrónico',
                type: 'email'
              },
              {
                field: 'Número telefónico',
                type: 'tel'
              },
              {
                field: 'Cantidad',
                type: 'number',
                default: response.data.ServiceList.MaxAmount[index]
              }
            ]
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
.main-container {
  display: flex;
  flex-direction: column;
  width: 100%;
}

.home {
  display: flex;
  flex-direction: row;
  padding: 25px;
  background-color: #EDEFF1;
  justify-content: space-between;
}

.header {
  display: flex;
  flex-direction: row;
  background-color: rgb(40, 75, 140);
  height: 70px;
  width: 100%;
}

.logo {
  margin-left: 20px;
  margin-top: 15px;
  height: 35px;
}

.services-container {
  flex: 7;
  display: flex;
  flex-direction: row;
  height: calc(100vh - 130px);
  background-color: white;
  margin-right: 25px;
  border-radius: 5px;
  border: 2px solid #EDEDED;
  padding: 25px;
  box-sizing: border-box;
}

.services {
  display: flex;
  justify-content: flex-start;
  flex-direction: row;
  flex-wrap: wrap;
  height: min-content;
}

.modal-form {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
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
