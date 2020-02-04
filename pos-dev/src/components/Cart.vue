<template>
  <div class="cart-container">
    <div class="current-cart">
      <div class="cart-header">
        <h3 class="cart-title">Artículos en carrito</h3>
      </div>
      <table>
        <tr class="table-header">
          <th>Cantidad</th>
          <th>Producto</th>
          <th>Costo</th>
          <th></th>
        </tr>
        <tr class="table-body" v-for="(item, index) in items" v-bind:key="index">
          <td>{{ item.qty }}</td>
          <td>{{ item.name }}</td>
          <td>{{ item.qty * item.value | currency }}</td>
          <td v-on:click="$emit('remove', { index, id: item.id })">
            <delete-icon  />
          </td>
        </tr>
      </table>
    </div>
    <div class="bottom-section">
      <div class="total-grid">
        <h3 class="subtotal">Subtotal</h3>
        <h3
          class="subtotal-value"
        >{{ total() | currency }} MXN</h3>
        <h3 class="total">Total</h3>
        <h3 class="total-value">{{ total() | currency }} MXN</h3>
      </div>
      <div class="action-buttons">
        <button class="button cancel" v-on:click="$emit('cancel')">CANCELAR Y BORRAR TODO</button>
        <button class="button send" v-on:click="$emit('pay')">COBRAR</button>
      </div>
    </div>
  </div>
</template>
<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import DeleteIcon from 'mdi-vue/Delete'
import Vue2Filters from 'vue2-filters'

Vue.use(Vue2Filters)
Vue.component('delete-icon', DeleteIcon)

export interface ICart {
  items: any[]
}

@Component
export default class Cart extends Vue implements ICart {
  @Prop() items: any[] = []

  total () {
    let result = 0
    if (!this.items) return result
    for (let i = 0; i < this.items.length; i++) {
      result += (this.items[i].value * this.items[i].qty)
    }
    return result
  }
}
</script>
<style lang="scss">
.cart-container {
  flex: 3;
  background-color: white;
  height: calc(100vh - 70px);
  margin: -25px -25px -25px 0px;
  border: 2px solid #ededed;
  box-sizing: border-box;
  padding: 25px;

  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.cart-header {
  width: 100%;
  background-color: #4567ae;
  border-radius: 5px 5px 0px 0px;
  display: flex;
  justify-content: space-around;
}

.cart-title {
  font-size: 16px;
  color: white;
}

table {
  border-collapse: collapse;
  width: 100%;
}

.table-header {
  height: 45px;
}

.table-body {
  height: 45px;
}

.current-cart {
  max-height: 75%;
  overflow-y: scroll;
  height: 60%;
}

.service {
  margin: 10px;
}

.bottom-section {
  display: flex;
  flex-direction: column;
}

.total-grid {
  display: inline-grid;
  justify-items: end;
  column-gap: 10px;
  grid-template-rows: 25px;
  width: 100%;
  justify-content: flex-end;
}

.total {
  font-weight: normal;
  grid-row-start: 2;
  grid-row-end: 3;
  grid-column-start: 1;
  grid-column-end: 2;
}

.total-value {
  grid-row-start: 2;
  grid-row-end: 3;
  grid-column-start: 2;
  grid-column-end: 3;
}

.subtotal {
  font-weight: normal;
  grid-row-start: 1;
  grid-row-end: 2;
  grid-column-start: 1;
  grid-column-end: 2;
}

.subtotal-value {
  grid-row-start: 1;
  grid-row-end: 2;
  grid-column-start: 2;
  grid-column-end: 3;
}

.action-buttons {
  width: 100%;
  display: flex;
  justify-content: space-between;
}

.button {
  border-radius: 5px;
  border: none;
  height: 50px;
  color: white;
  width: 48%;
  font-size: 14px;
}

.cancel {
  background-color: #b23026;
}

.send {
  background-color: #4567ae;
}
</style>
