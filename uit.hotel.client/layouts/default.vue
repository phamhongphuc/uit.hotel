<template>
    <div id="layout">
        <navbar- />
        <main>
            <sidebar- />
            <nuxt class="content" />
        </main>
        <no-ssr>
            <notifications :duration="1500" position="right bottom" />
        </no-ssr>
    </div>
</template>
<style lang="scss">
#layout {
    position: fixed;
    display: flex;
    flex-direction: column;
    width: 100%;
    height: 100%;
    user-select: none;
    > main {
        display: flex;
        flex: 1;
        max-height: calc(100% - 3.5rem);
        .content {
            position: relative;
            display: flex;
            flex: 1;
            flex-direction: column;
            padding: 0.5rem calc(0.5rem + 15px);
            overflow: hidden;
        }
    }
}
</style>
