<template>
    <div class="main-container">
        <div class="header">
        <img src="../../assets/logo-white.svg" class="logo">
        </div>
        <div class="home">
          <div class="services-container">
            <div class="services">
              <modalServicios
                class="service"
                v-for="(metodo, index) of metodos"
                v-bind:key="index"
                v-bind:metodo="metodo"
                v-on:modal="openModal($event)"
              ></modalServicios>
            </div>
          </div>
          <modal name="modal-service BillPay" :width="'60%'" :height="'auto'">
            <div class="modal-container">
              <h2 class="form-header">Datos del servicio BillPay</h2>
              <form class="modal-form">
                <div
                  class="modal-body"
                  v-for="(data, index) in openedService.modalData"
                  v-bind:key="index"
                >
                  <label v-bind:for="data.field">{{ data.field }}:</label>
                  <input v-bind:type="data.type" v-bind:id="data.field" v-bind:value="data.default" v-model="valuesBillPay[index]" />{{ data.default }}
                </div>
              </form>
              <div class="button-bottom">
                <button v-on:click="billPayTest()">Test</button>
                <button class="modal-default-button" v-on:click="closeModal('BillPay')">Cancelar</button>
              </div>
            </div>
          </modal>
          <modal name="modal-service TopUp" :width="'80%'" :height="'80%'">
            <div class="modal-container">
              <h2 class="form-header">Datos del servicio TopUp</h2>
              <form class="modal-form">
                <label>ProductCode</label>
                <input type="text" value="K9VG K3" />
                <label>TxReference</label>
                <input type="text" value='{\"Field1\":\"9876543211\"}' />
                <label>Amount</label>
                <input type="text" value="0" />
                <label>MPin</label>
                <input type="text" value="1111" />
                <label>Email</label>
                <input type="text" value="" />
                <label>ANI</label>
                <input type="text" value="" />
              </form>
              <div class="button-bottom">
                <button v-on:click="topUpTest()">Test</button>
                <button class="modal-default-button" v-on:click="closeModal('TopUp')">Cancelar</button>
              </div>
            </div>
          </modal>
        </div>
    </div>
</template>

<script>
import modalServicios from '@/components/modalServicios.vue'
import axios from 'axios'

export default {
  name: 'Config',
  components: {
    modalServicios
  },
  data: () => {
    return {
      form: {},
      openedService: {},
      valuesBillPay: ['', '', '', '', '', ''],
      metodos: [
        {
          'name': 'BillPay',
          'description': 'This API provides falicity to make transaction of Bill Payment services provided by respective Vendor.',
          modalData: [
            {
              field: 'ProductCode',
              type: 'text',
              default: 'P_NKIZ E0'
            },
            {
              field: 'BillPayData',
              type: 'text',
              default: '{"Field1":"9876543211"}'
            },
            {
              field: 'Amount',
              type: 'text'
            },
            {
              field: 'MPin',
              type: 'text',
              default: '1111'
            },
            {
              field: 'Email',
              type: 'text'
            },
            {
              field: 'ANI',
              type: 'text'
            }
          ]
        },
        {
          'name': 'TopUp',
          'description': 'This API provides falicity to make transaction of Bill Payment services provided by respective Vendor.'
        },
        {
          'name': 'GetBalance',
          'description': 'This API provide balance of e-value available in User’s wallet.'
        },
        {
          'name': 'PinSell',
          'description': 'This API provides falicity to make transaction of PIN (Voucher) Sell services provided by respective Vendor.'
        },
        {
          'name': 'GetProductDetails',
          'description': 'This API provides falicity to make transaction of Bill Payment services provided by respective Vendor.'
        },
        {
          'name': 'GetEnterpriseList',
          'description': 'This API provides list of Enterprise preconfigured for transaction of Business Payment service.'
        }
      ],
      openModal: function (metodo) {
        console.log(metodo.name)
        this.openedService = metodo
        if (metodo.name === 'BillPay') {
          this.$modal.show('modal-service BillPay')
        }
        if (metodo.name === 'TopUp') {
          this.$modal.show('modal-service TopUp')
        }
      },
      closeModal: function (metodo) {
        console.log(metodo)
        if (metodo === 'BillPay') {
          this.$modal.hide('modal-service BillPay')
        }
        if (metodo === 'TopUp') {
          this.$modal.hide('modal-service TopUp')
        }
      },
      billPayTest () {
        console.log(this.valuesBillPay)
        axios
          .post('localhost:5000/api/BillPay', {
            ProductCode: this.valuesBillPay[0],
            BillPayData: this.valuesBillPay[1],
            Amount: this.valuesBillPay[2],
            MPin: this.valuesBillPay[3],
            Email: this.valuesBillPay[4],
            ANI: this.valuesBillPay[5]
          })
          .then(response => {
            if (response.data.ResponseCode === '999') {
              this.$toastr.e('Error', response.data.ResponseDescription)
            }
            this.$toastr.s('Success', response.data.ResponseDescription)
            this.$modal.hide('modal-service BillPay')
          })
          .catch(error => {
            this.$toastr.e('Error', error)
          })
      },
      topUpTest () {
      }
    }
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
