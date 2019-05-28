<template>
    <div class="navbar-hr" />
</template>
<style lang="scss">
.navbar-hr {
    display: block;
    width: calc(100% + #{map-get($spacers, 2) * 2});
    height: 1.5px;
    margin: 0 -#{map-get($spacers, 2)};
    background-color: $border-color;
}
</style>
