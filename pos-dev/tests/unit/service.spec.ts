import { shallowMount } from '@vue/test-utils'
import Service from '@/components/Service.vue'

describe('Service.vue', () => {
  /**
   * Check that rendering of a service is done appropriately 
   * by the component.
   */
  it('renders props.data when passed', () => {
    const data = {
        name: 'test',
        inventory: 1,
        code: 1,
        price: 1
      }
    const wrapper = shallowMount(Service, {
      propsData: { service: data }
    })
    expect(wrapper.element.getElementsByTagName('h2')[0].innerHTML).toMatch(data.name)
    expect(wrapper.element.getElementsByTagName('p')[0].innerHTML).toMatch(`Código: ${data.code}`)
    expect(wrapper.element.getElementsByTagName('p')[1].innerHTML).toMatch(`Existencia: ${data.inventory}`)
    expect(wrapper.element.getElementsByTagName('h2')[1].innerHTML).toMatch(`$${data.price}.00 MXN`)
  })
})
