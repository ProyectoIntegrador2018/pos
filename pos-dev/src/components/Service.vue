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
      this.$emit('modal', this.service)
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
</style>
