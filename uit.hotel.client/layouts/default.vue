<template>
    <div id="layout">
        <navbar- />
        <main>
            <sidebar- />
            <nuxt class="content" />
        </main>
        <no-ssr>
            <notifications
                :duration="1500"
                animation-type="velocity"
                position="right bottom"
            />
        </no-ssr>
    </div>
</template>
<style lang="scss">
#layout {
    position: fixed;
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    user-select: none;
    > main {
        display: flex;
        flex: 1;
        max-height: calc(100% - 3.5rem);
        .content {
            overflow: hidden;
            position: relative;
            flex: 1;
            padding: 0.5rem calc(0.5rem + 15px);
            display: flex;
            flex-direction: column;
        }
    }
}
</style>
