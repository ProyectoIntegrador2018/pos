<template>
  <div @click="promptData" class="container">
      <div class="center-text even-row title">
          <h2>{{ service.name }}</h2>
      </div>
      <div class="even-row info">
          <div class="data">
              <p>Código: {{ service.code }}</p>
          </div>
          <div class="data">
              <p>Existencia: {{ service.inventory }}</p>
          </div>
      </div>
      <div class="center-text even-row price">
          <h2>{{ service.price | currency }} MXN</h2>
      </div>
      <modal name="modal-service">
            <div class="modal-mask">
                <div class="modal-wrapper">
                    <div class="modal-container">
                        <form action='#' method='post'>
                            <div class="modal-body" v-for="(value, propertyName) in service" v-bind:key="value" >
                                <label for='service-attr'> {{ propertyName }} : </label>
                                <input type="text" id="service-attr">
                            </div>
                        </form>
                        <button @click="closeModal">Enviar</button>
                        <button @click="closeModal">Cancelar</button>
                    </div>
                </div>
            </div>
      </modal>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import Vue2Filters from 'vue2-filters'

Vue.use(Vue2Filters)

@Component
export default class Service extends Vue {
    // This property receives the services connected to the component
    @Prop() private service!: any;
    promptData () {
      this.$modal.show('modal-service')
    }
    closeModal () {
      // close the modal
      this.$modal.hide('modal-service')
    }
}
</script>

<style>
.container {
    height: 125px;
    width: 225px;
    display: flex;
    flex-direction: column;
    border-radius: 8px;
    border-top: 2px solid rgb(40, 75, 140);
    background-color: rgb(244,244,244);
    cursor: pointer;
}

h2 {
    font-size: 22px;
    margin: auto;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.center-text {
    display: flex;
}

.even-row {
    height: 33.33%;
}

.title {
    padding: 0px 10px;
}

.info {
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
}

.data {
    background-color: rgb(244, 244, 244);
    width: 49%;
    display: flex;
}

p {
    margin: auto;
    font-size: 14px;
}

.price {
    background-color: rgb(40, 75, 140);
    border-bottom-left-radius: 8px;
    border-bottom-right-radius: 8px;
    color: white;
}
/*css for modal */
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.11);
  display: table;
  transition: opacity .3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.modal-container {
  width: 300px;
  margin: 0px auto;
  padding: 20px 30px;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.986);
  transition: all .3s ease;
  font-family: Helvetica, Arial, sans-serif;
}

.modal-header h3 {
  margin-top: 0;
  color: #42b983;
}

.modal-body {
  margin: 20px 0;
}

.modal-default-button {
  float: right;
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
  opacity: 1.0;
}

.modal-leave-active {
  opacity: 1.0;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
</style>
